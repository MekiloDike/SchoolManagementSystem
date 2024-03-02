//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace SchoolManagementSystem.Helper
//{
//    public class AuthorizeActionFilter : IAuthorizationFilter
//    {       
        
//            public void OnAuthorization(AuthorizationFilterContext context)
//            {
//                var token = context.HttpContext.Request.Cookies["jwt"];

//                if (string.IsNullOrEmpty(token))
//                {
//                    // Redirect to the login page
//                    context.Result = new RedirectToRouteResult(
//                        new RouteValueDictionary
//                        {
//                    { "controller", "User" },
//                    { "action", "LoginUser" }
//                        });
//                }
//            }
        

//    }
//}



