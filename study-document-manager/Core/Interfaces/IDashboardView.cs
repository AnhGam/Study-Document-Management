using System;
using System.Collections.Generic;
using study_document_manager.Core.Entities;

namespace study_document_manager.Core.Interfaces
{
    public interface IDashboardView
    {
        // Properties
        string SearchKeyword { get; }
        string SelectedSubject { get; }
        string SelectedType { get; }
        DateTime? FilterFromDate { get; }
        DateTime? FilterToDate { get; }
        double? FilterMinSize { get; }
        double? FilterMaxSize { get; }
        bool FilterIsImportant { get; }

        // Data Sources
        void SetDocumentList(List<StudyDocument> documents);
        void SetSubjects(List<string> subjects);
        void SetTypes(List<string> types);
        void UpdateStatusCount(int count);

        // Events
        event EventHandler SearchRequested;
        event EventHandler FilterApplied;
        event EventHandler RefreshRequested;
        event EventHandler<int> DeleteRequested;
        event EventHandler<int> EditRequested;
        event EventHandler AddRequested;
        event EventHandler<string> OpenFileRequested;
        event EventHandler ExportRequested;

        // UI Feedback
        void ShowMessage(string message);
        void ShowError(string message);
        bool ConfirmDelete();
    }
}
