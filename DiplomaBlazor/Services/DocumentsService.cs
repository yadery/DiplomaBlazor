using DiplomaBlazor.Enums;
using DiplomaBlazor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBlazor.Services
{
    internal class DocumentsService
    {
        private readonly DatabaseContext _context;
        public DocumentsService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Documents>> GetDocsAsync()
        {
            var query = await _context.GetTableAsync<Documents>();
            return await query.OrderBy(t => t.Id).ToArrayAsync();
        }

        public async Task<MethodDataResult<Documents>> SaveDocsAsync(Documents doc)
        {
            try
            {
                if (doc.Id == 0)
                {
                    //создать
                    await _context.AddItemAsync(doc);
                }
                else
                {
                    //изменить
                    await _context.UpdateItemAsync(doc);
                }
                return MethodDataResult<Documents>.Success(doc);
            }
            catch (Exception ex)
            {
                return MethodDataResult<Documents>.Fail(ex.Message);
            }
        }

        public async Task<Documents?> GetDocsAsync(int tripId, bool includeExpenses = false)
        {
            var doc = await _context.FindAsync<Documents>(tripId);            
            return doc;
        }
    }
}
