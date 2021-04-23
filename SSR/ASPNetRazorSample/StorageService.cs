using System.Collections.Generic;

namespace ASPNetRazorSample
{
    /// <summary>
    /// This service simulates a database, but actually holds the data just in-memory.
    /// </summary>
    public class StorageService
    {
        private readonly List<(string, string)> _storage = new List<(string, string)>();

        public IReadOnlyCollection<(string, string)> StoredComments => _storage.AsReadOnly();
        
        public void Add(string userName, string comment)
        {
            _storage.Add((userName, comment));
        }
    }
}