using AutoMapper;
using Chai.Models.DTO;
using Chai.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chai.API.App_Start
{
    /// <summary>
    ///  For Domain model to Viewmodel Mapping
    /// </summary>
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<AccountModel, AccountDTO>().ReverseMap();
            });
        }
    }

}