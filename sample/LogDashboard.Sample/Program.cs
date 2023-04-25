using LogDashboard;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddLogDashboard(new LogdashboardAccountAuthorizeFilter("admin", "123qwe"));

//Cookie����
//builder.Services.AddLogDashboard(
//    new LogdashboardAccountAuthorizeFilter("admin", "123qwe",
//        cookieOpt =>
//        {
//            cookieOpt.Expire = TimeSpan.FromDays(1);//��½����ʱ��,Ĭ��1��
//            cookieOpt.Secure = (filter) => $"{filter.UserName}&&{filter.Password}";//Token���ܹ����Զ���,��ΪĬ��ֵ
//        }));

var logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
logger.Debug("init main");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseLogDashboard();

app.MapControllers();

app.Run();