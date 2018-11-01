namespace Autumn.API.UoW
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ActionFilter : IActionFilter
    {
        private readonly IUnitOfWork unitOfWork;

        public ActionFilter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            System.Diagnostics.Debug.WriteLine("UnitOfWork: Ending.");

            if (actionExecutedContext == null)
            {
                return;
            }

            try
            {
                if (actionExecutedContext.Exception == null && actionExecutedContext.HttpContext.Response.StatusCode != (int)HttpStatusCode.BadRequest)
                {
                    this.unitOfWork.CommitTransaction();
                    System.Diagnostics.Debug.WriteLine("UoW Committed");
                }
                else
                {
                    try
                    {
                        this.unitOfWork.RollbackTransaction();
                        System.Diagnostics.Debug.WriteLine("UoW Rollback");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            System.Diagnostics.Debug.WriteLine("UoW Begin");
            this.unitOfWork.BeginTransaction();
        }
    }
}
