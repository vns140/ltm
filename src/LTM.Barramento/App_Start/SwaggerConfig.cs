using System.Web.Http;
using WebActivatorEx;
using LTM.Barramento;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http.Description;


namespace LTM.Barramento
{
    public class SwaggerConfig
    {
        /// <summary>
        /// Obtem o XML de Leitura 
        /// </summary>
        /// <returns></returns>
        protected static string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\bin\LTM.Barramento.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }

        internal static void RegisterSwagger(HttpConfiguration config)
        {


            config
                .EnableSwagger("docs/{apiVersion}/source", c =>
                {
                    c.SingleApiVersion("v1", "LTM API - Documentação")
                        .Description("Documentação oficial da API")
                        .Contact(cc => cc
                            .Name("Grupo LTM")
                            .Url("www.ltm.com"));
                    c.IncludeXmlComments(GetXmlCommentsPath());
                    c.DocumentFilter<AuthTokenOperation>();
                    c.IgnoreObsoleteActions();
                    c.OperationFilter<AuthorizationSecurityObjectOperationsFilter>();

                    c.ApiKey("Authorization")
                                 .Description("Standard Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"")
                                 .Name("Authorization")
                                 .In("header");


                })
                .EnableSwaggerUi(c =>
                {
                    c.EnableOAuth2Support("test-client-id", "test-realm", "Swagger UI");
                });
        }
    }

    public class AuthorizationSecurityObjectOperationsFilter : IOperationFilter
    {
        public string Name { get; private set; }

        public AuthorizationSecurityObjectOperationsFilter()
        {
            Name = "Authorization";
        }
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();
            var tokenAuthDict = new Dictionary<string, IEnumerable<string>>();
            tokenAuthDict.Add(Name, new List<string>());
            operation.security = new IDictionary<string, IEnumerable<string>>[] { tokenAuthDict };
        }
    }

    class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/api/token", new PathItem
            {
                post = new Operation
                {
                    tags = new List<string> { "Autenticação" },
                    consumes = new List<string>
                    {
                        "application/x-www-form-urlencoded"
                    },
                    parameters = new List<Parameter> {
                        new Parameter
                        {
                            type = "string",
                            name = "grant_type",
                            required = true,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "username",
                            required = false,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "password",
                            required = false,
                            @in = "formData"
                        }

                    }
                }
            });
        }
    }
}

