#pragma checksum "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17f439a0e092631730138d2238bb038d52a52b6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Home), @"mvc.1.0.view", @"/Views/Home/Home.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Home.cshtml", typeof(AspNetCore.Views_Home_Home))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\_ViewImports.cshtml"
using CSharpExam;

#line default
#line hidden
#line 2 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\_ViewImports.cshtml"
using CSharpExam.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17f439a0e092631730138d2238bb038d52a52b6f", @"/Views/Home/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"848971d457b335dbb6284278c438c7e06ffc929e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 73, true);
            WriteLiteral("<div class=\"head\">\r\n    <h1>Dojo Activity Center</h1>\r\n    <span>Welcome ");
            EndContext();
            BeginContext(74, 26, false);
#line 3 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
             Write(ViewBag.ThisUser.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(100, 344, true);
            WriteLiteral(@"!</span>
    <a href=""/logoff"">Log Off</a>
    <hr>
</div>
<table class=""table table-striped table-bordered"">
    <thead>
        <th>Activity</th>
        <th>Date and Time</th>
        <th>Duration</th>
        <th>Event Coordinator</th>
        <th>Number of Participants</th>
        <th>Actions</th>
    </thead>
    <tbody>
");
            EndContext();
#line 17 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
         if (ViewBag.AllActivities != null)
        {
            

#line default
#line hidden
#line 19 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
             foreach (var a in ViewBag.AllActivities)
            {

#line default
#line hidden
            BeginContext(570, 48, true);
            WriteLiteral("                <tr>\r\n                    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 618, "\"", 648, 2);
            WriteAttributeValue("", 625, "/activity/", 625, 10, true);
#line 22 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
WriteAttributeValue("", 635, a.ActivityId, 635, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(649, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(651, 7, false);
#line 22 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                                                     Write(a.Title);

#line default
#line hidden
            EndContext();
            BeginContext(658, 35, true);
            WriteLiteral("</a></td>\r\n                    <td>");
            EndContext();
            BeginContext(694, 30, false);
#line 23 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                   Write(a.ActivityDate.ToString("M/d"));

#line default
#line hidden
            EndContext();
            BeginContext(724, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(726, 2, true);
            WriteLiteral("@ ");
            EndContext();
            BeginContext(729, 33, false);
#line 23 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                                                      Write(a.ActivityDate.ToString("h:mmtt"));

#line default
#line hidden
            EndContext();
            BeginContext(762, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(794, 13, false);
#line 24 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                   Write(a.ActDuration);

#line default
#line hidden
            EndContext();
            BeginContext(807, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(809, 9, false);
#line 24 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                                  Write(a.ActUnit);

#line default
#line hidden
            EndContext();
            BeginContext(818, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 25 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                     if (ViewBag.Creators != null)
                    {
                        

#line default
#line hidden
#line 27 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                         foreach (var c in ViewBag.Creators)
                        {
                            

#line default
#line hidden
#line 29 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                             if (a.PlannerId == c.UserId)
                            {

#line default
#line hidden
            BeginContext(1079, 36, true);
            WriteLiteral("                                <td>");
            EndContext();
            BeginContext(1116, 11, false);
#line 31 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                               Write(c.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1127, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 32 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                            }

#line default
#line hidden
#line 32 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                             
                        }

#line default
#line hidden
#line 33 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                         
                    }

#line default
#line hidden
            BeginContext(1215, 24, true);
            WriteLiteral("                    <td>");
            EndContext();
            BeginContext(1240, 25, false);
#line 35 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                   Write(a.ActivityAttendees.Count);

#line default
#line hidden
            EndContext();
            BeginContext(1265, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 36 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                     if (a.PlannerId == ViewBag.ThisUser.UserId)
                    {

#line default
#line hidden
            BeginContext(1361, 30, true);
            WriteLiteral("                        <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1391, "\"", 1419, 2);
            WriteAttributeValue("", 1398, "/delete/", 1398, 8, true);
#line 38 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
WriteAttributeValue("", 1406, a.ActivityId, 1406, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1420, 18, true);
            WriteLiteral(">Delete</a></td>\r\n");
            EndContext();
#line 39 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                    }
                    else
                    {
                        int temp = 0;
                        

#line default
#line hidden
#line 43 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                         foreach (var u in a.ActivityAttendees)
                        {
                            if (u.User.UserId == ViewBag.ThisUser.UserId)
                            {
                                temp = u.ParticipationId;
                            }
                        }

#line default
#line hidden
#line 50 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                         if (temp == 0)
                        {

#line default
#line hidden
            BeginContext(1932, 34, true);
            WriteLiteral("                            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1966, "\"", 1992, 2);
            WriteAttributeValue("", 1973, "/join/", 1973, 6, true);
#line 52 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
WriteAttributeValue("", 1979, a.ActivityId, 1979, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1993, 16, true);
            WriteLiteral(">Join</a></td>\r\n");
            EndContext();
#line 53 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(2093, 34, true);
            WriteLiteral("                            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2127, "\"", 2146, 2);
            WriteAttributeValue("", 2134, "/leave/", 2134, 7, true);
#line 56 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
WriteAttributeValue("", 2141, temp, 2141, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2147, 17, true);
            WriteLiteral(">Leave</a></td>\r\n");
            EndContext();
#line 57 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                        }

#line default
#line hidden
#line 57 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
                         
                    }

#line default
#line hidden
            BeginContext(2214, 23, true);
            WriteLiteral("                </tr>\r\n");
            EndContext();
#line 60 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
            }

#line default
#line hidden
#line 60 "C:\Users\James\Desktop\CD\C#\CSharpExam\Views\Home\Home.cshtml"
             
        }

#line default
#line hidden
            BeginContext(2263, 89, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<button><a class=\"btn\" href=\"/New\">Add New Activity!</a></button>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591