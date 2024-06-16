using ProjectASP.Application;
using ProjectASP.DataAccess;
using ProjectASP.Domain;

namespace ProjectASP.API.Core
{

    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public Guid Log(Exception ex, IApplicationActor actor)
        {
            var id = Guid.NewGuid();
            Console.WriteLine(ex.Message + " ID: " + id);

            return id;
        }
    }

    public class DbExceptionLogger : IExceptionLogger
    {
        private readonly AspContext _aspContext;

        public DbExceptionLogger(AspContext aspContext)
        {
            _aspContext = aspContext;
        }

        public Guid Log(Exception ex, IApplicationActor actor)
        {
            Guid id = Guid.NewGuid();
            //ID, Message, Time, StrackTrace
            Log log = new()
            {
                LogId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow
            };

            //_aspContext.Entry(log).State = EntityState.Added;

            _aspContext.Logs.Add(log);

            _aspContext.SaveChanges();

            return id;
        }
    }
}
