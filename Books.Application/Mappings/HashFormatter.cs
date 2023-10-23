using AutoMapper;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Mappings
{
    public class HashFormatter : IValueConverter<int, string>
    {
        private readonly IHashids _hashids;

        public HashFormatter(IHashids hashids)
        {
            _hashids = hashids;
        }

        public string Convert(int sourceMember, ResolutionContext context)
        {
            return _hashids.Encode(sourceMember);
        }
    }
}
