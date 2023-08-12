using Microsoft.AspNetCore.Mvc.Razor;

namespace AttendanceChecker.Views.Custom
{
    public class CustomViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            // Use context.ActionContext to determine the current action
            var action = context.ActionContext.ActionDescriptor.DisplayName;

            // Specify custom view locations based on the action
            if (action.Contains("AdminDashboard")) // Adjust this condition based on your action's name
            {
                return new[]
                {
                "~/Views/Home/AdminDashboard.cshtml"
                };
            } else if (action.Contains("UserDashboard"))
            {
                return new[]
               {
                "~/Views/Home/UserDashboard.cshtml"
                };
            } else if (action.Contains("Login"))
            {
                return new[]
               {
                "~/Views/Home/Login.cshtml"
                };
            }

            // Use the default view locations
            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // No need to implement this method
        }

    }
}
