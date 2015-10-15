using Abot.Poco;
using Microsoft.Framework.Configuration;

namespace Taygeta.WebLoader
{
    internal static class StringParseExtension
    {
        public static int IntParse(this string s)
        {
            return int.Parse(s);
        }

        public static bool BoolParse(this string s)
        {
            return bool.Parse(s);
        }
    }

    public class VacancyCrawlConfiguration : CrawlConfiguration
    {
        /// <summary>
        /// Reads configuration values from the supplied IConfiguration implementation
        /// </summary>
        /// <param name="config">IConfiguration implementation</param>
        public VacancyCrawlConfiguration(IConfiguration config)
        {
            MaxConcurrentThreads = config["VacancyCrawler:MaxConcurrentThreads"]?.IntParse() ?? MaxConcurrentThreads;
            MaxPagesToCrawl = config["VacancyCrawler:MaxPagesToCrawl"]?.IntParse() ?? MaxPagesToCrawl;
            MaxPagesToCrawlPerDomain = config["VacancyCrawler:MaxPagesToCrawlPerDomain"]?.IntParse() ?? MaxPagesToCrawlPerDomain;
            MaxPageSizeInBytes = config["VacancyCrawler:MaxPageSizeInBytes"]?.IntParse() ?? MaxPageSizeInBytes;
            UserAgentString = config["VacancyCrawler:UserAgentString"] ?? UserAgentString;
            CrawlTimeoutSeconds = config["VacancyCrawler:CrawlTimeoutSeconds"]?.IntParse() ?? CrawlTimeoutSeconds;
            DownloadableContentTypes = config["VacancyCrawler:DownloadableContentTypes"] ?? DownloadableContentTypes;
            IsUriRecrawlingEnabled = config["VacancyCrawler:IsUriRecrawlingEnabled"]?.BoolParse() ?? IsUriRecrawlingEnabled;
            IsExternalPageCrawlingEnabled = config["VacancyCrawler:IsExternalPageCrawlingEnabled"]?.BoolParse() ?? IsExternalPageCrawlingEnabled;
            IsExternalPageLinksCrawlingEnabled = config["VacancyCrawler:IsExternalPageLinksCrawlingEnabled"]?.BoolParse() ?? IsExternalPageLinksCrawlingEnabled;
            HttpServicePointConnectionLimit = config["VacancyCrawler:HttpServicePointConnectionLimit"]?.IntParse() ?? HttpServicePointConnectionLimit;
            HttpRequestTimeoutInSeconds = config["VacancyCrawler:HttpRequestTimeoutInSeconds"]?.IntParse() ?? HttpRequestTimeoutInSeconds;
            HttpRequestMaxAutoRedirects = config["VacancyCrawler:HttpRequestMaxAutoRedirects"]?.IntParse() ?? HttpRequestMaxAutoRedirects;
            IsHttpRequestAutoRedirectsEnabled = config["VacancyCrawler:IsHttpRequestAutoRedirectsEnabled"]?.BoolParse() ?? IsHttpRequestAutoRedirectsEnabled;
            IsHttpRequestAutomaticDecompressionEnabled = config["VacancyCrawler:IsHttpRequestAutomaticDecompressionEnabled"]?.BoolParse() ?? IsHttpRequestAutomaticDecompressionEnabled;
            IsSendingCookiesEnabled = config["VacancyCrawler:IsSendingCookiesEnabled"]?.BoolParse() ?? IsSendingCookiesEnabled;
            IsSslCertificateValidationEnabled = config["VacancyCrawler:IsSslCertificateValidationEnabled"]?.BoolParse() ?? IsSslCertificateValidationEnabled;
            IsRespectUrlNamedAnchorOrHashbangEnabled = config["VacancyCrawler:IsRespectUrlNamedAnchorOrHashbangEnabled"]?.BoolParse() ?? IsRespectUrlNamedAnchorOrHashbangEnabled;
            IsForcedLinkParsingEnabled = config["VacancyCrawler:IsForcedLinkParsingEnabled"]?.BoolParse() ?? IsForcedLinkParsingEnabled;
            IsAlwaysLogin = config["VacancyCrawler:IsAlwaysLogin"]?.BoolParse() ?? IsAlwaysLogin;
            IsRespectRobotsDotTextEnabled = config["VacancyCrawler:IsRespectRobotsDotTextEnabled"]?.BoolParse() ?? IsRespectRobotsDotTextEnabled;
            IsRespectMetaRobotsNoFollowEnabled = config["VacancyCrawler:IsRespectMetaRobotsNoFollowEnabled"]?.BoolParse() ?? IsRespectMetaRobotsNoFollowEnabled;
            IsRespectAnchorRelNoFollowEnabled = config["VacancyCrawler:IsRespectAnchorRelNoFollowEnabled"]?.BoolParse() ?? IsRespectAnchorRelNoFollowEnabled;
            IsIgnoreRobotsDotTextIfRootDisallowedEnabled = config["VacancyCrawler:IsIgnoreRobotsDotTextIfRootDisallowedEnabled"]?.BoolParse() ?? IsIgnoreRobotsDotTextIfRootDisallowedEnabled;
            MinAvailableMemoryRequiredInMb = config["VacancyCrawler:MinAvailableMemoryRequiredInMb"]?.IntParse() ?? MinAvailableMemoryRequiredInMb;
            MaxMemoryUsageInMb = config["VacancyCrawler:MaxMemoryUsageInMb"]?.IntParse() ?? MaxMemoryUsageInMb;
            MaxMemoryUsageCacheTimeInSeconds = config["VacancyCrawler:MaxMemoryUsageCacheTimeInSeconds"]?.IntParse() ?? MaxMemoryUsageCacheTimeInSeconds;
            MaxCrawlDepth = config["VacancyCrawler:MaxCrawlDepth"]?.IntParse() ?? MaxCrawlDepth;
            MaxRetryCount = config["VacancyCrawler:MaxRetryCount"]?.IntParse() ?? MaxRetryCount;
            MinRetryDelayInMilliseconds = config["VacancyCrawler:MinRetryDelayInMilliseconds"]?.IntParse() ?? MinRetryDelayInMilliseconds;
            MaxRobotsDotTextCrawlDelayInSeconds = config["VacancyCrawler:MaxRobotsDotTextCrawlDelayInSeconds"]?.IntParse() ?? MaxRobotsDotTextCrawlDelayInSeconds;
            MinCrawlDelayPerDomainMilliSeconds = config["VacancyCrawler:MinCrawlDelayPerDomainMilliSeconds"]?.IntParse() ?? MinCrawlDelayPerDomainMilliSeconds;
            LoginUser = config["VacancyCrawler:LoginUser"] ?? LoginUser;
            LoginPassword = config["VacancyCrawler:LoginPassword"] ?? LoginPassword;
            RobotsDotTextUserAgentString = config["VacancyCrawler:RobotsDotTextUserAgentString"] ?? RobotsDotTextUserAgentString;
            if (config["VacancyCrawler:ExtensionValues:Proxy"] != null)
                ConfigurationExtensions.Add("Proxy", config["VacancyCrawler:ExtensionValues:Proxy"]);
        }
    }
}
