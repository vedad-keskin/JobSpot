using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Client = IdentityServer4.Models.Client;
using EntityClient =  IdentityServer4.EntityFramework.Entities.Client;
using IdentityResource = IdentityServer4.Models.IdentityResource;
using IdentityResourceEntity = IdentityServer4.EntityFramework.Entities.IdentityResource;

using ApiScope = IdentityServer4.Models.ApiScope;
using ApiScopeEntity = IdentityServer4.EntityFramework.Entities.ApiScope;

using ApiResource = IdentityServer4.Models.ApiResource;
using ApiResourceEntity = IdentityServer4.EntityFramework.Entities.ApiResource;

namespace Identity
{
    public class CustomMappingProfile : Profile
    {
        public CustomMappingProfile()
        {
            CreateMap<Client, EntityClient>()
                .ForMember(dest => dest.ClientSecrets, opt => opt.MapFrom(src => src.ClientSecrets.Select(s => new ClientSecret { Value = s.Value, Type = s.Type, Description = s.Description, Expiration = s.Expiration })))
                .ForMember(dest => dest.RedirectUris, opt => opt.MapFrom(src => src.RedirectUris.Select(uri => new ClientRedirectUri { RedirectUri = uri })))
                .ForMember(dest => dest.PostLogoutRedirectUris, opt => opt.MapFrom(src => src.PostLogoutRedirectUris.Select(uri => new ClientPostLogoutRedirectUri { PostLogoutRedirectUri = uri })))
                .ForMember(dest => dest.AllowedGrantTypes, opt => opt.MapFrom(src => src.AllowedGrantTypes.Select(type => new ClientGrantType { GrantType = type })))
                .ForMember(dest => dest.AllowedScopes, opt => opt.MapFrom(src => src.AllowedScopes.Select(scope => new ClientScope { Scope = scope })))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.ClientName))
                .ForMember(dest => dest.FrontChannelLogoutUri, opt => opt.MapFrom(src => src.FrontChannelLogoutUri))
                .ForMember(dest => dest.AllowOfflineAccess, opt => opt.MapFrom(src => src.AllowOfflineAccess))
                .ForMember(dest => dest.RequirePkce, opt => opt.MapFrom(src => src.RequirePkce))
                .ForMember(dest => dest.RequireConsent, opt => opt.MapFrom(src => src.RequireConsent))
                .ForMember(dest => dest.AllowPlainTextPkce, opt => opt.MapFrom(src => src.AllowPlainTextPkce))
                .ReverseMap();

            CreateMap<IdentityResource, IdentityResourceEntity>()
                 .ForMember(dest => dest.UserClaims, opt => opt.MapFrom(src => src.UserClaims.Select(claim => new IdentityResourceClaim { Type = claim })))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ReverseMap();

            CreateMap<ApiScope, ApiScopeEntity>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<ApiResource, ApiResourceEntity>()
                .ForMember(dest => dest.Scopes, opt => opt.MapFrom(src => src.Scopes.Select(scope => new ApiResourceScope { Scope = scope })))
                .ForMember(dest => dest.Secrets, opt => opt.MapFrom(src => src.ApiSecrets.Select(secret => new ApiResourceSecret { Value = secret.Value, Type = secret.Type, Description = secret.Description, Expiration = secret.Expiration })))
                .ForMember(dest => dest.UserClaims, opt => opt.MapFrom(src => src.UserClaims.Select(claim => new ApiResourceClaim { Type = claim })))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
