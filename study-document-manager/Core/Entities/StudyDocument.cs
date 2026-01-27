using System;

namespace study_document_manager.Core.Entities
{
    public class StudyDocument
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string MonHoc { get; set; }
        public string Loai { get; set; }
        public string DuongDan { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayThem { get; set; }
        public double? KichThuoc { get; set; }
        public string TacGia { get; set; }
        public bool QuanTrong { get; set; }
        public string Tags { get; set; }
        public DateTime? Deadline { get; set; }

        public StudyDocument()
        {
            NgayThem = DateTime.Now;
            QuanTrong = false;
        }
    }
}
