using VolvoFinalProject;

namespace VolvoFinalProject.Api.Model.Models
{
    public class ErrorViewModel : Exception
    {
        public ErrorViewModel()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailsVM>();
        }

        public ErrorViewModel(string logref, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailsVM>();
            AddError(logref, message);
        }

        public string TraceId { get; private set; }
        public List<ErrorDetailsVM> Errors { get; private set; }

        public class ErrorDetailsVM
        {
            public ErrorDetailsVM(string logref, string message)
            {
                Logref = logref;
                Message = message;
            }

            public string Logref { get; private set; }

            public string Message { get; private set; }
        }

        public void AddError(string logref, string message)
        {
            Errors.Add(new ErrorDetailsVM(logref, message));
        }
    }
}