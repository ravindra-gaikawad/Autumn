namespace Autumn.WebApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Autumn.WebApp.Models;
    using Newtonsoft.Json;

    public class BookService : IBookService
    {
        private readonly HttpClient httpClient;

        public BookService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        Task IBookService.AddAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        void IBookService.Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        void IBookService.Edit(Book entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<Book> IBookService.FindAll(Expression<Func<Book, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<Book> IBookService.FindAsync(Expression<Func<Book, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Book>> IBookService.GetAllAsync()
        {
            var response = await httpClient.GetAsync("http://localhost:81/api/api/books", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Book>>(data);
        }

        Task<Book> IBookService.GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
