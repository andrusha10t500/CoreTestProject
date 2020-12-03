using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MvcMovie.Models;
// using MvcMovie.ViewModels;

namespace MvcMovie.Controllers {
    [Route("")]
    public class PhoneController : Controller {
        List<Phone> phones;
        List<Company> Companies;

        public PhoneController() {
            Company apple = new Company {
                Id = 1,
                Name = "Apple",
                Country = "США"
            };
            Company microsoft = new Company {
                Id = 2,
                Name = "Samsung",
                Country = "Республика Корея"
            };
            Company google = new Company {
                Id = 3,
                Name = "Google",
                Country = "США"
            };

            Companies = new List<Company>{ apple, microsoft, google };

            phones = new List<Phone> {
                new Phone { 
                    Id = 1, 
                    Manufacturer = apple,
                    Name="iPhone X",
                    Price = 56000
                },
                new Phone { 
                    Id = 2, 
                    Manufacturer = apple,
                    Name="iPhone XZ",
                    Price = 41000
                },
                new Phone { 
                    Id = 1, 
                    Manufacturer = microsoft,
                    Name="Galaxy 9",
                    Price = 9000
                },
                new Phone { 
                    Id = 1, 
                    Manufacturer = microsoft,
                    Name="Galaxy 10",
                    Price = 40000
                },
                new Phone { 
                    Id = 1, 
                    Manufacturer = google,
                    Name="Pixel 2",
                    Price = 30000
                },
                new Phone { 
                    Id = 1, 
                    Manufacturer = google,
                    Name="Pixel XL",
                    Price = 50000
                }                
            };           
        }
        [HttpGet("")]
        public IActionResult Index(int? companyId){

            List<CompanyModel> compModels = Companies
                .Select(c => new CompanyModel {Id = c.Id, Name = c.Name})
                .ToList();

            compModels.Insert(0, new CompanyModel{ Id = 0, Name = "Все"});

            IndexViewModel ivm = new IndexViewModel { Companies = compModels, Phones = phones };

            if(companyId != null && companyId > 0) {
                ivm.Phones = phones.Where(p => p.Manufacturer.Id == companyId);
            }

            return View(ivm);
        }
    }
}