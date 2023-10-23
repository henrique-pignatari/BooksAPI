using AutoMapper;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Mappings
{
    public class IntFromHash : IValueConverter<string, int>
    {
        private readonly IHashids _hashids;
        public IntFromHash(IHashids hashids)
        {
            _hashids = hashids;
        }

        public int Convert(string sourceMember, ResolutionContext context)
        {
            return _hashids.DecodeSingle(sourceMember);
        }
    }
}
