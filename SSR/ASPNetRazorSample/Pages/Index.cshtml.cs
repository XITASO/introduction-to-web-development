using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ASPNetRazorSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly StorageService _storageService;

        public IndexModel(ILogger<IndexModel> logger,
            StorageService storageService)
        {
            _logger = logger;
            _storageService = storageService;
        }

        public IReadOnlyCollection<(string, string)> StoredComments => _storageService.StoredComments;

        [BindProperty]
        public string UserName { get; set; }
        
        [BindProperty]
        public string Comment { get; set; }
        
        /// <summary>
        /// Initial request via GET
        /// </summary>
        public void OnGet()
        {
        }
        
        /// <summary>
        /// Method is called on a POST request (Form submit)
        /// </summary>
        public IActionResult OnPost()
        {
            _logger.LogInformation("Username is {userName}", UserName);
            _storageService.Add(UserName, Comment);

            // This redirect helps when refreshing the page to not trigger POST again
            return Redirect("/");
        }
    }
}