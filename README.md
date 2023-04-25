
## Nuget包

| Package Name |  Version | Downloads
|--------------|  ------- | ----
| LogDashboard.Authorization | [![NuGet](https://img.shields.io/nuget/v/LogDashboard.Authorization)](https://www.nuget.org/packages/LogDashboard.Authorization) | [![NuGet](https://img.shields.io/nuget/dt/LogDashboard.Authorization)](https://www.nuget.org/packages/LogDashboard.Authorization)|

---------

# `LogDashboard.Authorization`
> 这是一个基于LogDashboard的扩展授权包，新增了一套新的AuthorizationFilter授权过滤器，内置了登陆页面

-------

## 功能介绍
- [x] 内置了登陆授权页面
- [x] 开箱即用

------

# 项目接入

**Step 1 : 安装包，通过Nuget安装包**

```powershell
Install-Package LogDashboard.Authorization
```

**Step 2 : 配置 Startup 启动类**

```csharp
public class Startup
{
    //...
    
    public void ConfigureServices(IServiceCollection services)
    {
        //configuration
        services.AddLogDashboard(new LogdashboardAccountAuthorizeFilter("accout", "password"));
    }    
}
```

------

### [LogDashboard介绍文档](https://doc.logdashboard.net/ru-men/quickstart)

----------

## Web界面
- 登录页

![](https://raw.githubusercontent.com/Bryan-Cyf/LogDashboard.Authorization/master/media/login.png)

## 更多示例

查看 [使用例子](https://github.com/Bryan-Cyf/LogDashboard.Authorization/tree/master/sample)
