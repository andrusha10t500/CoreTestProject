using MvcMovie.Models;
using System.Collections.Generic;
using System;

public class IndexViewModel {
    public IEnumerable<Phone> Phones { get; set; }
    public IEnumerable<CompanyModel> Companies { get; set; }
}
