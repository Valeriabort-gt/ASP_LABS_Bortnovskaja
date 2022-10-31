using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using AutoMapper;
using MediatR;
using Persistence;
using Application.Rents.Quieres.GetRentList;
using Application.Rooms.Quieres.GetRoomList;
using Application.Invoices.Quieres.GetInvoiceList;
using Application.Employees.Quieres.GetEmployeeList;

namespace WebAPI.MiddlewareEndpoints
{
    public static class RouteEndpoints
    {
        private readonly static string _styles = "<style>" +
            "a {display: block; padding: 5px 10px 5px 10px; font-size: 130%; " +
            "background-color: #BBF4FF; text-decoration: none; color: black;" +
            "margin-top: 10px; border-radius: 5px;}" +
            "body {display:flex; flex-direction:column; align-items: center; align-items:center;}" +
            "h1 {text-align: center;}" +
            ".bg-yellow {background-color: #ebeb34;}" +
            ".bg-green {background-color: #34eb3a;}" +
            ".bg-red {background-color: red; }" +
            "</style>";

        public static string Template(string title, string body)
        {
            return "<html><head>" +
                $"<title>{title}</title>" +
                "<meta charset=\"utf-8\" />" +
                _styles +
                "</head><body>" +
                $"<h1>{title}</h1>{body}" +
                "</body></html>";
        }

        public static void Info(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync(Template("Info",
                    "<script type = \"text/javascript\"> " +
                    "var code = navigator.appCodeName;" +
                    "var name = navigator.appName;" +
                    "var vers = navigator.appVersion; " +
                    "var platform = navigator.platform;" +
                    "var cook = navigator.cookieEnabled;" +
                    "var je = navigator.javaEnabled();" +
                    "var ua = navigator.userAgent;" +
                    "document.write('Браузер: ' + name + " +
                    "'<br />Версия браузера: ' + vers +" +
                    "'<br />Кодовое название браузера: ' + code +" +
                    "'<br />Платформа: ' + platform +" +
                    "'<br />Поддержка cookie: ' + cook +" +
                    "'<br />Поддержка JavaScript: ' + je +" +
                    "'<br />userAgent: ' + ua);" +
                    "</script>" +
                    "<a href=\"/\">Back</a><br>"));
            });
        }

        public static void GetRents(IApplicationBuilder app)
        {
            app.Run(async context =>
            {

                var mediator = context.RequestServices.GetService<IMediator>();
                var query = new GetRentListQuery
                {
                    cacheKey = "rents"
                };
                var vm = mediator.Send(query).Result.rents;

                var testvm = mediator.Send(new GetRoomListQuery()).Result.rooms;

                string htmlString =
                    "<a href=\"/\">Back</a><br>" +
                    "<table border=1>" +
                    "<tr>" +
                    "<th>Id</th>" +
                    "<th>Entry Date</th>" +
                    "<th>Exit Date</th>" +
                    "<th>Num of Room</th>" +
                    "<th>Square</th>" +
                    "<th>Description</th>" +
                    "<th>Org name</th>" +
                    "<th>Org email</th>" +
                    "</tr>";

                foreach (var item in vm)
                {
                    htmlString += "<tr>" +
                                $"<td>{item.id}</td>" +
                                $"<td>{item.entryDate.ToShortDateString()}</td>" +
                                $"<td>{item.exitDate.ToShortDateString()}</td>" +
                                $"<td>{item.room.numOfRoom}</td>" +
                                $"<td>{item.room.square}</td>" +
                                $"<td>{item.room.description}</td>" +
                                $"<td>{item.organization.name}</td>" +
                                $"<td>{item.organization.email}</td>" +
                                "</tr>";
                }

                htmlString += "</table>";

                await context.Response.WriteAsync(Template("Rents", htmlString));
            });
        }

        public static void FirstSearch(IApplicationBuilder app)
        {

            app.Run(async context =>
            {
                var mediator = context.RequestServices.GetService<IMediator>();
                var queryEmployee = new GetEmployeeListQuery();
                var employeeVM = mediator.Send(queryEmployee).Result.employees;

                var queryInvoice = new GetInvoiceListQuery();
                var invoiceVm = mediator.Send(queryInvoice).Result.invoices;

                string keyInput = "orgName";
                string keySelected = "employee";
                string keyMultiselect = "invoiceNumber";

                string htmlString = "<form>";
                if (context.Request.Cookies.ContainsKey(keyInput))
                {
                    string orgName = context.Request.Query[keyInput];
                    string cookieOrgName = context.Request.Cookies[keyInput];
                    if(orgName != cookieOrgName && orgName != null)
                    {
                        context.Response.Cookies.Append(keyInput, orgName);
                        htmlString += $"<input value={orgName} name={keyInput}>";
                    }
                    else
                    {
                        htmlString += $"<input value={context.Request.Cookies[keyInput]} name={keyInput}>";
                    }
                }
                else
                {
                    string orgName = context.Request.Query[keyInput];
                    if(orgName != null)
                    {
                        context.Response.Cookies.Append(keyInput, orgName);
                        htmlString += $"<input name={keyInput} placeholder=orgName value={orgName}>";
                    }
                    else
                    {
                        htmlString += $"<input name={keyInput} placeholder=orgName>";
                    }
                }


                htmlString += "<br>";
                htmlString += $"<select name={keySelected}>";

                if (context.Request.Cookies.ContainsKey(keySelected))
                {
                    string employeeSelected = context.Request.Query[keySelected];
                    string cookieEmployeeSelected = context.Request.Cookies[keySelected];
                    if (employeeSelected != cookieEmployeeSelected && employeeSelected != null)
                    {
                        context.Response.Cookies.Append(keySelected, employeeSelected);
                        foreach (var item in employeeVM)
                        {
                            if ($"{item.id} || {item.name} || {item.surname}" == employeeSelected)
                            {
                                htmlString += $"<option selected>{item.id} || {item.name} || {item.surname}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.id} || {item.name} || {item.surname}</option>";
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in employeeVM)
                        {
                            if ($"{item.id} || {item.name} || {item.surname}" == cookieEmployeeSelected)
                            {
                                htmlString += $"<option selected>{item.id} || {item.name} || {item.surname}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.id} || {item.name} || {item.surname}</option>";
                            }
                        }
                    }
                }
                else
                {
                    string employeeSelected = context.Request.Query[keySelected];
                    if (employeeSelected != null)
                    {
                        context.Response.Cookies.Append(keySelected, employeeSelected);
                        foreach (var item in employeeVM)
                        {
                            if ($"{item.id} || {item.name} || {item.surname}" == employeeSelected)
                            {
                                htmlString += $"<option selected>{item.id} || {item.name} || {item.surname}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.id} || {item.name} || {item.surname}</option>";
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in employeeVM)
                        {
                            htmlString += $"<option>{item.id} || {item.name} || {item.surname}</option>";
                        }
                    }
                }
                htmlString += "</select>";
                htmlString += "<br>";
                htmlString += $"<select name={keyMultiselect} multiple size = 10>";


                if (context.Request.Cookies.ContainsKey(keyMultiselect))
                {
                    string[] invoiceNumber = context.Request.Query[keyMultiselect].ToString().Split(',');
                    string[] cookieInvoiceNumber = context.Request.Cookies[keyMultiselect].ToString().Split(',') ;
                    if (invoiceNumber != null && isArrayOdinakovie(invoiceNumber, cookieInvoiceNumber) != true)
                    {
                        context.Response.Cookies.Append(keyMultiselect, String.Join(',', invoiceNumber));
                        foreach (var item in invoiceVm)
                        {
                            bool isContain = false;
                            foreach(var elem in invoiceNumber)
                            {
                                if($"{item.number}" == elem)
                                {
                                    isContain = true;
                                    break;
                                }
                            }
                            if (isContain)
                            {
                                htmlString += $"<option selected>{item.number}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.number}</option>";
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in invoiceVm)
                        {
                            bool isContain = false;
                            foreach (var elem in cookieInvoiceNumber)
                            {
                                if ($"{item.number}" == elem)
                                {
                                    isContain = true;
                                    break;
                                }
                            }
                            if (isContain)
                            {
                                htmlString += $"<option selected>{item.number}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.number}</option>";
                            }
                        }
                    }
                }
                else
                {
                    string[] cookieInvoiceNumber = context.Request.Query[keyMultiselect].ToString().Split(',');
                    if (context.Request.Query[keyMultiselect].Count != 0)
                    {
                        context.Response.Cookies.Append(keyMultiselect, String.Join(',', cookieInvoiceNumber));
                        foreach (var item in invoiceVm)
                        {

                            bool isContain = false;
                            foreach (var elem in cookieInvoiceNumber)
                            {
                                if ($"{item.number}" == elem)
                                {
                                    isContain = true;
                                    break;
                                }
                            }
                            if (isContain)
                            {
                                htmlString += $"<option selected>{item.number}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.number}</option>";
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in invoiceVm)
                        {
                            htmlString += $"<option>{item.number}</option>";
                        }
                    }
                }

                htmlString += "</select>";

                htmlString += "<br>";
                htmlString += "<button type=submit>Добавить в куки</button>";
                htmlString += "</form>";
                await context.Response.WriteAsync(Template("Search Form 1", htmlString));
            });
        }

        public static void SecondSearch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var mediator = context.RequestServices.GetService<IMediator>();
                var queryEmployee = new GetEmployeeListQuery();
                var employeeVM = mediator.Send(queryEmployee).Result.employees;

                var queryInvoice = new GetInvoiceListQuery();
                var invoiceVm = mediator.Send(queryInvoice).Result.invoices;

                string keyInput = "orgName";
                string keySelected = "employee";
                string keyMultiselect = "invoiceNumber";

                string htmlString = "<form>";
                if (context.Session.Keys.Contains(keyInput))
                {
                    string orgName = context.Request.Query[keyInput];
                    string sessionOrgName = context.Session.GetString(keyInput);
                    if (orgName != sessionOrgName && orgName != null)
                    {
                        context.Session.SetString(keyInput, orgName);
                        htmlString += $"<input value={orgName} name={keyInput}>";
                    }
                    else
                    {
                        htmlString += $"<input value={context.Request.Cookies[keyInput]} name={keyInput}>";
                    }
                }
                else
                {
                    string orgName = context.Request.Query[keyInput];
                    if (orgName != null)
                    {
                        context.Session.SetString(keyInput, orgName);
                        htmlString += $"<input name={keyInput} placeholder=orgName value={orgName}>";
                    }
                    else
                    {
                        htmlString += $"<input name={keyInput} placeholder=orgName>";
                    }
                }


                htmlString += "<br>";
                htmlString += $"<select name={keySelected}>";

                if (context.Session.Keys.Contains(keySelected))
                {
                    string employeeSelected = context.Request.Query[keySelected];
                    string cookieEmployeeSelected = context.Session.GetString(keySelected);
                    if (employeeSelected != cookieEmployeeSelected && employeeSelected != null)
                    {
                        context.Session.SetString(keySelected, employeeSelected);
                        foreach (var item in employeeVM)
                        {
                            if ($"{item.id} || {item.name} || {item.surname}" == employeeSelected)
                            {
                                htmlString += $"<option selected>{item.id} || {item.name} || {item.surname}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.id} || {item.name} || {item.surname}</option>";
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in employeeVM)
                        {
                            if ($"{item.id} || {item.name} || {item.surname}" == cookieEmployeeSelected)
                            {
                                htmlString += $"<option selected>{item.id} || {item.name} || {item.surname}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.id} || {item.name} || {item.surname}</option>";
                            }
                        }
                    }
                }
                else
                {
                    string employeeSelected = context.Request.Query[keySelected];
                    if (employeeSelected != null)
                    {
                        context.Session.SetString(keySelected, employeeSelected);
                        foreach (var item in employeeVM)
                        {
                            if ($"{item.id} || {item.name} || {item.surname}" == employeeSelected)
                            {
                                htmlString += $"<option selected>{item.id} || {item.name} || {item.surname}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.id} || {item.name} || {item.surname}</option>";
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in employeeVM)
                        {
                            htmlString += $"<option>{item.id} || {item.name} || {item.surname}</option>";
                        }
                    }
                }
                htmlString += "</select>";
                htmlString += "<br>";
                htmlString += $"<select name={keyMultiselect} multiple size = 10>";


                if (context.Session.Keys.Contains(keyMultiselect))
                {
                    string[] invoiceNumber = context.Request.Query[keyMultiselect].ToString().Split(',');
                    string[] cookieInvoiceNumber = context.Session.GetString(keyMultiselect).ToString().Split(',');
                    if (invoiceNumber != null && isArrayOdinakovie(invoiceNumber, cookieInvoiceNumber) != true)
                    {
                        context.Session.SetString(keyMultiselect, String.Join(',', invoiceNumber));
                        foreach (var item in invoiceVm)
                        {
                            bool isContain = false;
                            foreach (var elem in invoiceNumber)
                            {
                                if ($"{item.number}" == elem)
                                {
                                    isContain = true;
                                    break;
                                }
                            }
                            if (isContain)
                            {
                                htmlString += $"<option selected>{item.number}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.number}</option>";
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in invoiceVm)
                        {
                            bool isContain = false;
                            foreach (var elem in cookieInvoiceNumber)
                            {
                                if ($"{item.number}" == elem)
                                {
                                    isContain = true;
                                    break;
                                }
                            }
                            if (isContain)
                            {
                                htmlString += $"<option selected>{item.number}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.number}</option>";
                            }
                        }
                    }
                }
                else
                {
                    string[] cookieInvoiceNumber = context.Request.Query[keyMultiselect].ToString().Split(',');
                    if (context.Request.Query[keyMultiselect].Count != 0)
                    {
                        context.Session.SetString(keyMultiselect, String.Join(',', cookieInvoiceNumber));
                        foreach (var item in invoiceVm)
                        {

                            bool isContain = false;
                            foreach (var elem in cookieInvoiceNumber)
                            {
                                if ($"{item.number}" == elem)
                                {
                                    isContain = true;
                                    break;
                                }
                            }
                            if (isContain)
                            {
                                htmlString += $"<option selected>{item.number}</option>";
                            }
                            else
                            {
                                htmlString += $"<option>{item.number}</option>";
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in invoiceVm)
                        {
                            htmlString += $"<option>{item.number}</option>";
                        }
                    }
                }

                htmlString += "</select>";

                htmlString += "<br>";
                htmlString += "<button type=submit>Добавить в куки</button>";
                htmlString += "</form>";
                await context.Response.WriteAsync(Template("Search Form 1", htmlString));
            });
        }

        private static bool isArrayOdinakovie(string[] first, string[] second)
        {
            if(first.Length != second.Length)
            {
                return true;
            }
            for(var i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
