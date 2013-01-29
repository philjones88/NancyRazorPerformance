using System;
using System.Collections.Generic;
using System.Dynamic;
using Nancy;

namespace NancyRazorPerformance.Public.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
                {
                    dynamic model = new ExpandoObject();
                    model.Testimonials = new List<Testimonial>();

                    for (int i = 0; i <= 10; i++)
                    {
                        model.Testimonials.Add(new Testimonial
                        {
                            Name = "Bob Smith " + i,
                            Content = "Blah blah blah. Blah blah blah. Blah blah blah. Blah blah blah. Blah blah blah. Blah blah blah. Blah blah blah. Blah blah blah. Blah blah blah. Blah blah blah.",
                            At = DateTime.Now.Date.AddDays(-10 + i)
                        });
                    }

                    model.Trips = new List<Trip>();

                    for (int i = 0; i <= 5; i++)
                    {
                        model.Trips.Add(new Trip
                        {
                            Name = "Trip " + i,
                            Content = "<p>blah blah blah<p><p>blah blah blah<p><p>blah blah blah<p><p>blah blah blah<p><p>blah blah blah<p>"
                        });
                    }

                    model.Stuff = new List<string>();

                    for (int i = 0; i < 50; i++)
                    {
                        model.Stuff.Add("Blah blah blah");
                    }

                    return View["Home", model];
                };
        }
    }
}