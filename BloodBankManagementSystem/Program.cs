using AutoMapper;
using BloodBankManagementSystem.Components;
using BloodBankManagementSystem.Components.Account;
using BloodBankManagementSystem.DAL;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using BloodBankManagementSystem.BLL.Automapper;
using BloodBankManagementSystem.BLL.Services.Donation;
using BloodBankManagementSystem.BLL.Services.Policies;
using BloodBankManagementSystem.BLL.Services.Questions;
using BloodBankManagementSystem.BLL.Services.Settings;
using BloodBankManagementSystem.BLL.Services;
using BloodBankManagementSystem.BLL;
using Shared.Messages;
using General;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using BloodBankManagementSystem;
using BLL.Services.Users;

try
{
    var builder = WebApplication.CreateBuilder(args);

    //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44383/api/") });

    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents().AddCircuitOptions(o =>
        {
            if (builder.Environment.IsDevelopment()) 
            {
                o.DetailedErrors = true;
            }
        }); 
    //.AddInteractiveWebAssemblyComponents();

    builder.Services.AddCascadingAuthenticationState();
    builder.Services.AddScoped<IdentityUserAccessor>();
    builder.Services.AddScoped<IdentityRedirectManager>();
    builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

    builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
        .AddIdentityCookies();

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddSignInManager()
        .AddDefaultTokenProviders();

    builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

    builder.Services.AddMudServices();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //builder.Services.AddControllers()
    //       .AddJsonOptions(options =>
    //       {
    //           options.JsonSerializerOptions.PropertyNamingPolicy = null;
    //       }); ;


    var mapperConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new MapProfile());
    });

    IMapper mapper = mapperConfig.CreateMapper();
    builder.Services.AddSingleton(mapper);

    #region Services
    builder.Services.AddScoped<IRepository<ApplicationDbContext>, Repository<ApplicationDbContext>>();
    builder.Services.AddScoped<IMessageService, MessageService>();

    builder.Services.AddScoped<IAntibodyService, AntibodyService>();
    builder.Services.AddScoped<IAntibodyService, AntibodyService>();
    builder.Services.AddScoped<IBagLotService, BagLotService>();
    builder.Services.AddScoped<IBagManufacturerService, BagManufacturerService>();
    builder.Services.AddScoped<IBagTypeService, BagTypeService>();
    builder.Services.AddScoped<IBloodBankService, BloodBankService>();
    builder.Services.AddScoped<ICityService, CityService>();
    builder.Services.AddScoped<IClinicsService, ClinicsService>();
    builder.Services.AddScoped<IComponentService, ComponentService>();
    builder.Services.AddScoped<IComponentPreparationService, ComponentPreparationService>();
    builder.Services.AddScoped<IComponentPreparationMethodService, ComponentPreparationMethodService>();
    builder.Services.AddScoped<IComponentStorageSystemService, ComponentStorageSystemService>();
    builder.Services.AddScoped<IDonationSymptomService, DonationSymptomService>();
    builder.Services.AddScoped<IDonationTherapyService, DonationTherapyService>();
    builder.Services.AddScoped<IDonationTypeService, DonationTypeService>();
    builder.Services.AddScoped<IDonorService, DonorService>();
    builder.Services.AddScoped<IEquipmentService, EquipmentService>();
    builder.Services.AddScoped<IExaminationService, ExaminationService>();
    builder.Services.AddScoped<IPolicyService, PolicyService>();
    builder.Services.AddScoped<IProblemService, ProblemService>();
    builder.Services.AddScoped<IProcessService, ProcessService>();
    builder.Services.AddScoped<IQuestionService, QuestionService>();
    builder.Services.AddScoped<IReactionService, ReactionService>();
    builder.Services.AddScoped<ISuspensionReasonService, SuspensionReasonService>();
    builder.Services.AddScoped<IUnitOfMeasurementService, UnitOfMeasurementService>();

    //builder.Services.AddScoped<IUserService, UserService>();
    #endregion


    //#region WebAssemblyServices
    //builder.Services.AddTransient<IClinicService, ClinicService>();
    //builder.Services.AddTransient<ICitiesService, CitiesService>();
    //builder.Services.AddTransient<IDonationSymptomsService, DonationSymptomsService>();
    //builder.Services.AddTransient<IDonationTherapiesService, DonationTherapiesService>();
    //builder.Services.AddTransient<IAntibodiesService, AntibodiesService>();
    //builder.Services.AddTransient<IQuestionsService, QuestionsService>();
    //builder.Services.AddTransient<IPoliciesService, PoliciesService>();
    //#endregion

    //builder.Services.AddHttpClient();

    builder.Services.AddSingleton(Log.Logger);

    builder.Logging.ClearProviders();

    builder.Host.UseSerilog();

    Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MSSqlServerSinkOptions()
        {
            AutoCreateSqlDatabase = false,
            AutoCreateSqlTable = false,
            TableName = "LogEntries"
        })
    .CreateLogger();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
        app.UseMigrationsEndPoint();
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseSerilogRequestLogging();

    app.UseMiddleware<RequestLoggingMiddleware>();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();
    //.AddInteractiveWebAssemblyRenderMode()
    //.AddAdditionalAssemblies(typeof(BloodBankManagementSystem.Components._Imports).Assembly);

    app.MapIdentityApi<ApplicationUser>();
    //app.MapControllers();

    // Add additional endpoints required by the Identity /Account Razor components.
    app.MapAdditionalIdentityEndpoints();

    app.Run();

}
catch (Exception ex)
{

    throw;
}
