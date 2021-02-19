using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace DataAccess.MappingProfile
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                // Add as many of these lines as you need to map your objects
                CreateMap<Models.System.AdminUser, Models.System.DTO.AdminUserDTO>();
                CreateMap<Models.System.DTO.AdminUserDTO, Models.System.AdminUser>();

                CreateMap<Models.System.EmailSettings, Models.System.DTO.EmailSettingsDTO>();
                CreateMap<Models.System.DTO.EmailSettingsDTO, Models.System.EmailSettings>();

                CreateMap<Models.System.Recipient, Models.System.DTO.RecipientDTO>();
                CreateMap<Models.System.DTO.RecipientDTO, Models.System.Recipient>();

                CreateMap<Models.System.License, Models.System.DTO.LicenseDTO>();
                CreateMap<Models.System.DTO.LicenseDTO, Models.System.License>();

                CreateMap<Models.System.Customer, Models.System.DTO.CustomerDTO>();
                CreateMap<Models.System.DTO.CustomerDTO, Models.System.Customer>();

                CreateMap<Models.System.Site, Models.System.DTO.SiteDTO>();
                CreateMap<Models.System.DTO.SiteDTO, Models.System.Site>();

                CreateMap<Models.System.Product, Models.System.DTO.ProductDTO>();
                CreateMap<Models.System.DTO.ProductDTO, Models.System.Product>();

            }
        }
    }


