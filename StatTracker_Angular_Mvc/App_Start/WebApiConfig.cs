﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace StatTracker_Angular_Mvc
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver =
              new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "courses",
                routeTemplate: "api/facilities/{facilityId}/courses",
                defaults: new { facilityId = RouteParameter.Optional, controller = "Facilities", action = "Courses"}
            );

            config.Routes.MapHttpRoute(
                name: "tees",
                routeTemplate: "api/course/{courseId}/tees",
                defaults: new { courseId = RouteParameter.Optional, controller = "Course", action = "Tees" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}