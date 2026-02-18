using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using study_document_manager.Core.Entities;
using study_document_manager.Core.Interfaces;

namespace study_document_manager.Infrastructure.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private string _connectionString;

        public DocumentRepository()
        {
            _connectionString = DatabaseHelper.ConnectionString;
        }

        private StudyDocument MapRowToEntity(DataRow row)
        {
            return new StudyDocument
            {
                Id = Convert.ToInt32(row["id"]),
                Ten = row["ten"].ToString(),
                MonHoc = row["mon_hoc"].ToString(),
                Loai = row["loai"].ToString(),
                DuongDan = row["duong_dan"].ToString(),
                GhiChu = row["ghi_chu"].ToString(),
                NgayThem = Convert.ToDateTime(row["ngay_them"]),
                KichThuoc = row["kich_thuoc"] != DBNull.Value ? Convert.ToDouble(row["kich_thuoc"]) : (double?)null,
                TacGia = row["tac_gia"].ToString(),
                QuanTrong = Convert.ToInt32(row["quan_trong"]) == 1,
                Tags = row["tags"].ToString(),
                Deadline = row["deadline"] != DBNull.Value ? Convert.ToDateTime(row["deadline"]) : (DateTime?)null
            };
        }

        private List<StudyDocument> ExecuteAndMap(string query, SQLiteParameter[] parameters = null)
        {
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            List<StudyDocument> list = new List<StudyDocument>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRowToEntity(row));
            }
            return list;
        }

        public List<StudyDocument> GetAll()
        {
            return ExecuteAndMap("SELECT * FROM tai_lieu WHERE (is_deleted IS NULL OR is_deleted = 0) ORDER BY ngay_them DESC");
        }

        public StudyDocument GetById(int id)
        {
            string query = "SELECT * FROM tai_lieu WHERE id = @id";
            var parameters = new SQLiteParameter[] { new SQLiteParameter("@id", id) };
            var list = ExecuteAndMap(query, parameters);
            return list.Count > 0 ? list[0] : null;
        }

        public List<StudyDocument> Search(string keyword)
        {
             string query = @"SELECT * FROM tai_lieu
                           WHERE (is_deleted IS NULL OR is_deleted = 0)
                           AND (ten LIKE @keyword
                           OR mon_hoc LIKE @keyword
                           OR ghi_chu LIKE @keyword)
                           ORDER BY ngay_them DESC";

             var parameters = new SQLiteParameter[] { new SQLiteParameter("@keyword", "%" + keyword + "%") };
             return ExecuteAndMap(query, parameters);
        }

        public List<StudyDocument> Filter(string subject, string type)
        {
            string query = "SELECT * FROM tai_lieu WHERE (is_deleted IS NULL OR is_deleted = 0)";
            var parameters = new List<SQLiteParameter>();

            if (!string.IsNullOrEmpty(subject) && subject != "Tất cả")
            {
                query += " AND mon_hoc = @mon_hoc";
                parameters.Add(new SQLiteParameter("@mon_hoc", subject));
            }

            if (!string.IsNullOrEmpty(type) && type != "Tất cả")
            {
                query += " AND loai = @loai";
                parameters.Add(new SQLiteParameter("@loai", type));
            }

            query += " ORDER BY ngay_them DESC";
            return ExecuteAndMap(query, parameters.ToArray());
        }

        public List<StudyDocument> SearchAdvanced(string keyword, string subject, string type, DateTime? fromDate, DateTime? toDate, double? minSize, double? maxSize, bool? isImportant)
        {
             // Reusing logic from DatabaseHelper but returning Entities
             // For simplicity, we can call DatabaseHelper.SearchDocumentsAdvanced if we modified it to return List,
             // but here we duplicate query logic to keep layers clean (or ideally refactor DatabaseHelper to be a pure DB facade).
             // Given the timeline, I will map the result of DatabaseHelper if possible, OR rewrite query here.
             // I will rewrite query here to be independent.

            string baseQuery = @"SELECT * FROM tai_lieu WHERE (is_deleted IS NULL OR is_deleted = 0)";
            List<SQLiteParameter> parameterList = new List<SQLiteParameter>();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                baseQuery += " AND (ten LIKE @keyword OR mon_hoc LIKE @keyword OR ghi_chu LIKE @keyword OR tags LIKE @keyword)";
                parameterList.Add(new SQLiteParameter("@keyword", "%" + keyword + "%"));
            }

            if (!string.IsNullOrEmpty(subject) && subject != "Tất cả")
            {
                baseQuery += " AND mon_hoc = @mon_hoc";
                parameterList.Add(new SQLiteParameter("@mon_hoc", subject));
            }

            if (!string.IsNullOrEmpty(type) && type != "Tất cả")
            {
                baseQuery += " AND loai = @loai";
                parameterList.Add(new SQLiteParameter("@loai", type));
            }

            if (fromDate.HasValue)
            {
                baseQuery += " AND date(ngay_them) >= date(@fromDate)";
                parameterList.Add(new SQLiteParameter("@fromDate", fromDate.Value.ToString("yyyy-MM-dd")));
            }

            if (toDate.HasValue)
            {
                baseQuery += " AND date(ngay_them) <= date(@toDate)";
                parameterList.Add(new SQLiteParameter("@toDate", toDate.Value.ToString("yyyy-MM-dd")));
            }

            if (minSize.HasValue)
            {
                baseQuery += " AND kich_thuoc >= @minSize";
                parameterList.Add(new SQLiteParameter("@minSize", minSize.Value));
            }

            if (maxSize.HasValue)
            {
                baseQuery += " AND kich_thuoc <= @maxSize";
                parameterList.Add(new SQLiteParameter("@maxSize", maxSize.Value));
            }

            if (isImportant.HasValue && isImportant.Value == true)
            {
                baseQuery += " AND quan_trong = 1";
            }

            baseQuery += " ORDER BY ngay_them DESC";

            return ExecuteAndMap(baseQuery, parameterList.ToArray());
        }

        public bool Add(StudyDocument doc)
        {
            return DatabaseHelper.InsertDocument(doc.Ten, doc.MonHoc, doc.Loai, doc.DuongDan, doc.GhiChu, doc.KichThuoc, doc.TacGia, doc.QuanTrong, doc.Tags, doc.Deadline);
        }

        public bool Update(StudyDocument doc)
        {
             return DatabaseHelper.UpdateDocument(doc.Id, doc.Ten, doc.MonHoc, doc.Loai, doc.DuongDan, doc.GhiChu, doc.KichThuoc, doc.TacGia, doc.QuanTrong, doc.Tags, doc.Deadline);
        }

        public bool Delete(int id)
        {
            return DatabaseHelper.DeleteDocument(id);
        }

        public List<string> GetDistinctSubjects()
        {
            var dt = DatabaseHelper.GetDistinctSubjects();
            var list = new List<string>();
            foreach(DataRow row in dt.Rows) list.Add(row["mon_hoc"].ToString());
            return list;
        }

        public List<string> GetDistinctTypes()
        {
            var dt = DatabaseHelper.GetDistinctTypes();
             var list = new List<string>();
            foreach(DataRow row in dt.Rows) list.Add(row["loai"].ToString());
            return list;
        }

        public List<string> GetDistinctTags()
        {
            return DatabaseHelper.GetDistinctTags();
        }

        public List<StudyDocument> GetUpcomingDeadlines(int days)
        {
            string query = @"SELECT * FROM tai_lieu
                            WHERE deadline IS NOT NULL
                            AND date(deadline) >= date('now', 'localtime')
                            AND date(deadline) <= date('now', 'localtime', '+' || @days || ' days')
                            ORDER BY deadline ASC";
             var parameters = new SQLiteParameter[] { new SQLiteParameter("@days", days) };
             return ExecuteAndMap(query, parameters);
        }

        public List<StudyDocument> GetOverdueDocuments()
        {
             string query = @"SELECT * FROM tai_lieu
                            WHERE deadline IS NOT NULL
                            AND date(deadline) < date('now', 'localtime')
                            ORDER BY deadline ASC";
            return ExecuteAndMap(query);
        }
    }
}
