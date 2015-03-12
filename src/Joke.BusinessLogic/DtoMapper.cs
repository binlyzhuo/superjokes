using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Joke.Model.Domain;
using Joke.Model.Dto;

namespace Joke.BusinessLogic
{
    public class DtoMapper
    {
        public static void AutoMapper()
        {
            Mapper.CreateMap<T_Joke, JokeDto>();
            Mapper.CreateMap<T_Category, CategoryDto>();
        }
    }
}
