namespace BookingHotelsAPI.Extensions
{
    public static class ApplicationServicesExtenstions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddControllers();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddAutoMapper(typeof(BookingProfile));

            services.AddDbContext<AppDbContext>(opt =>
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                opt.UseSqlServer(connectionString);
            });


            services.AddIdentityCore<User>(opt =>
            {
                // Add Identity Options Here
            }).AddEntityFrameworkStores<AppDbContext>()
                        .AddSignInManager<SignInManager<User>>();

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod()
                    .WithOrigins("https://booking-hotels-angular.vercel.app");
                });
            });

            return services;
        }
    }
}
