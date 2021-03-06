﻿using AutoMapper;

namespace Perlink.Services.Helpers
{
    public static class MapHelper
    {
        public static TDestination MapFrom<TDestination>(object source, TDestination dest)
        {
            var _source = source.GetType();
            var _dest = dest.GetType();
            var _mapperCfg = new MapperConfiguration(cfg => cfg.CreateMap(_source,  _dest));
            var _mapper = _mapperCfg.CreateMapper();
            var ret = _mapper.Map<object, TDestination>(source, dest);
            return ret;
        }
    }
}