using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreLibrary.Models;

public class Book : BaseEntity
{
    public string Name { get; set; }
    public int PageCount { get; set; }
    public int ThemeId { get; set; }
    public int? StudentId { get; set; }
    // Navigation Property
    public Student Student { get; set; }
    public List<Author> Authors { get; set; }
    public Theme Theme { get; set; }
}
