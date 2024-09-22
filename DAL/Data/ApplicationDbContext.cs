using DAL.Data.Base.Models;
using DAL.Data.DatabaseModels;
using DAL.Data.DatabaseModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BloodBankManagementSystem.DAL;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }


    #region Questionaire
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Response> Responses { get; set; }

    #endregion Questionaire

    #region Configurations
    public DbSet<Antibody> Antibodies { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<DonationType> DonationTypes { get; set; }
    public DbSet<DonationTherapy> DonationTherapies { get; set; }
    public DbSet<DonationSymptom> DonationSymptoms { get; set; }
    public DbSet<Problem> Problems { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<SuspensionReason> SuspensionReasons { get; set; }
    public DbSet<StorageSystem> StorageSystems { get; set; }
    public DbSet<ComponentPreparationMethod> ComponentPreparationMethods { get; set; }
    public DbSet<UnitOfMeasurement> UnitsOfMeasurements { get; set; }
    public DbSet<BagType> BagTypes { get; set; }
    public DbSet<BagManufacturer> BagManufacturers { get; set; }
    public DbSet<BagLot> BagLots { get; set; }
    public DbSet<DestructionReason> DestructionReasons { get; set; }
    #endregion

    #region Donation 
    public DbSet<Donation> Donations { get; set; }
    #endregion

    #region Donors
    public DbSet<Donor> Donors { get; set; }
    public DbSet<SuspendedDonors> SuspendedDonors { get; set; }
    public DbSet<DeletedDonors> DeletedDonors { get; set; }

    #endregion

    #region Examinations 
    public DbSet<Examination> Examinations { get; set; }
    public DbSet<ExaminationResult> ExaminationResults { get; set; }
    public DbSet<ReferenceValue> ReferenceValues { get; set; }
    #endregion

    #region Processes
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Process> Processes { get; set; }
    public DbSet<ProcessDetail> ProcessesDetails{get;set;}
    #endregion

    #region Components
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentStorageSystem> ComponentStorageSystems { get; set; }
    public DbSet<ComponentPreparation> ComponentPreparations { get; set; }
    #endregion

    #region Units 
    public DbSet<Unit> Units { get; set; }
    public DbSet<PooledUnit> PooledUnits { get; set; }
    public DbSet<FractionedUnit> FractionedUnit { get; set; }
    public DbSet<DestroyedUnit> DestroyedUnits { get; set; }
    #endregion

    #region Permissions
    public DbSet<Policy> Policies { get; set; }
    public DbSet<UserPolicy> UserPolicies { get; set; }
    #endregion 
    public DbSet<LogEntry> LogEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
        string ROLE_ID = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6";

        //seed admin role
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "SuperAdmin",
            NormalizedName = "SUPERADMIN",
            Id = ROLE_ID,
            ConcurrencyStamp = ROLE_ID
        });

        //create user
        var appUser = new ApplicationUser
        {
            Id = ADMIN_ID,
            Email = "admin@gmail.com",
            EmailConfirmed = true,
            //FirstName = "Frank",
            //LastName = "Ofoedu",
            UserName = "raizela@gmail.com",
            NormalizedUserName = "RAIZELA@GMAIL.COM"
        };

        //set user password
        PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
        appUser.PasswordHash = ph.HashPassword(appUser, "Admin123*");

        //seed user
        builder.Entity<ApplicationUser>().HasData(appUser);

        //set user role to admin
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = ROLE_ID,
            UserId = ADMIN_ID
        });
    }

    //public override int SaveChanges()
    //{
    //    UpdateAuditEntities();
    //    return base.SaveChanges();
    //}


    //public override int SaveChanges(bool acceptAllChangesOnSuccess)
    //{
    //    UpdateAuditEntities();
    //    return base.SaveChanges(acceptAllChangesOnSuccess);
    //}


    //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    //{
    //    UpdateAuditEntities();
    //    return base.SaveChangesAsync(cancellationToken);
    //}


    //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    //{
    //    UpdateAuditEntities();
    //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    //}


    //private void UpdateAuditEntities()
    //{
    //    GetCurrentUser();
    //    var modifiedEntries = ChangeTracker.Entries()
    //        .Where(x => x.Entity is AuditableEntity && x.State is EntityState.Added or EntityState.Modified or EntityState.Deleted);


    //    foreach (var entry in modifiedEntries)
    //    {
    //        var entity = (AuditableEntity)entry.Entity;
    //        var now = DateTime.Now;

    //        switch (entry.State)
    //        {
    //            case EntityState.Added:
    //                entity.IsDeleted = false;
    //                entity.CreatedDate = now;
    //                entity.CreatedBy = "user";
    //                break;
    //            case EntityState.Deleted:
    //                entry.State = EntityState.Modified;
    //                entity.IsDeleted = true;
    //                entity.DeletedBy = "user";
    //                base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
    //                base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
    //                break;
    //            case EntityState.Detached:
    //            case EntityState.Unchanged:
    //            case EntityState.Modified:
    //            default:
    //                base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
    //                base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
    //                break;
    //        }

    //        entity.LastUpdatedDate = now;
    //        entity.LastUpdatedBy = "user";
    //    }
    //}

    //public void GetCurrentUser()
    //{
    //    var test = _httpContextAccessor.HttpContext.User.Identity.Name;
    //    //// Access the HttpContext and retrieve the current user ID
    //    //var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    //    //// Return the current user from the database based on the user ID
    //    //if (userId != null)
    //    //{
    //    //    return Users.FirstOrDefault(u => u.Id == userId);
    //    //}

    //    //return null; // Return null if no user is found
    //}
}
