using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace FifaApp.Client
{
    public class MyHttpService
    {
        //GET, POST, PUT, DELETE,...

        public async Task Get(string url)
        {
            var httpClient = new HttpClient();

            //   httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "EAACEdEose0cBAIyvDPsIVsZAqopHWokzZC9ZAN9N8Gz39hreZChUeRDutavcWC0woxJdGHC3ZBK3Lov29LCpK6LvEKE3bRZAkNKusSrz4QxdQOwMJEdWZAvULK2bJtcvh1T00XUi5REijUTMGrZCPviiLpgZBJJ3CsEQDr4cWysZBiOcZAzdGFeJz2IJSFVZAClm3BUZD");

            // var response = await httpClient.GetAsync("https://cp-mlxprod-static.microsoft.com/011611-1002/en-us/coursedetails.xml?v=1446696614994");

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://vnexpress.net");

            //    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "EAACEdEose0cBAIyvDPsIVsZAqopHWokzZC9ZAN9N8Gz39hreZChUeRDutavcWC0woxJdGHC3ZBK3Lov29LCpK6LvEKE3bRZAkNKusSrz4QxdQOwMJEdWZAvULK2bJtcvh1T00XUi5REijUTMGrZCPviiLpgZBJJ3CsEQDr4cWysZBiOcZAzdGFeJz2IJSFVZAClm3BUZD");


            var response = await httpClient.SendAsync(requestMessage);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var result = await response.Content.ReadAsStringAsync();
                //...
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
                var stream = await response.Content.ReadAsStreamAsync();

                System.Xml.Serialization.XmlSerializer serializer = new XmlSerializer(typeof(CourseDetails));
                var r = serializer.Deserialize(stream);
                if (r is CourseDetails myobjc)
                {
                }
            }
            //var course= JsonConvert.DeserializeObject<Course>(result);
        }


        public async Task Post()
        {
            var httpClient = new HttpClient();
            var bodyString = "act=login&email=khuongntrd@gmail.com&isAJ=1&pass=123456789&remember=false";
            var bodyContent = new StringContent(bodyString, Encoding.UTF8, "application/x-www-form-urlencoded");
            var request = new HttpRequestMessage(HttpMethod.Post, "http://www.hellochao.vn/user.php");
            request.Content = bodyContent;

            var response = await httpClient.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

        }


        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class CourseDetails
        {

            private ushort courseNumberField;

            private CourseDetailsOverview overviewField;

            private object instructorsField;

            private object evaluationLinksField;

            private CourseDetailsRequirements requirementsField;

            private CourseDetailsAssessment assessmentField;

            private ushort courseIdField;

            private string versionField;

            /// <remarks/>
            public ushort CourseNumber
            {
                get
                {
                    return this.courseNumberField;
                }
                set
                {
                    this.courseNumberField = value;
                }
            }

            /// <remarks/>
            public CourseDetailsOverview Overview
            {
                get
                {
                    return this.overviewField;
                }
                set
                {
                    this.overviewField = value;
                }
            }

            /// <remarks/>
            public object Instructors
            {
                get
                {
                    return this.instructorsField;
                }
                set
                {
                    this.instructorsField = value;
                }
            }

            /// <remarks/>
            public object EvaluationLinks
            {
                get
                {
                    return this.evaluationLinksField;
                }
                set
                {
                    this.evaluationLinksField = value;
                }
            }

            /// <remarks/>
            public CourseDetailsRequirements Requirements
            {
                get
                {
                    return this.requirementsField;
                }
                set
                {
                    this.requirementsField = value;
                }
            }

            /// <remarks/>
            public CourseDetailsAssessment Assessment
            {
                get
                {
                    return this.assessmentField;
                }
                set
                {
                    this.assessmentField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort courseId
            {
                get
                {
                    return this.courseIdField;
                }
                set
                {
                    this.courseIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string version
            {
                get
                {
                    return this.versionField;
                }
                set
                {
                    this.versionField = value;
                }
            }
        }

        /// <remarks/>

        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class CourseDetailsOverview
        {

            private CourseDetailsOverviewDetails detailsField;

            private string introductionField;

            private string prerequistiesField;

            private string objectivesField;

            private string liveEventsField;

            /// <remarks/>
            public CourseDetailsOverviewDetails Details
            {
                get
                {
                    return this.detailsField;
                }
                set
                {
                    this.detailsField = value;
                }
            }

            /// <remarks/>
            public string Introduction
            {
                get
                {
                    return this.introductionField;
                }
                set
                {
                    this.introductionField = value;
                }
            }

            /// <remarks/>
            public string Prerequisties
            {
                get
                {
                    return this.prerequistiesField;
                }
                set
                {
                    this.prerequistiesField = value;
                }
            }

            /// <remarks/>
            public string Objectives
            {
                get
                {
                    return this.objectivesField;
                }
                set
                {
                    this.objectivesField = value;
                }
            }

            /// <remarks/>
            public string LiveEvents
            {
                get
                {
                    return this.liveEventsField;
                }
                set
                {
                    this.liveEventsField = value;
                }
            }
        }

        /// <remarks/>

        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class CourseDetailsOverviewDetails
        {

            private string courseLengthField;

            private string publishedDateField;

            private string languageField;

            private string audiencesField;

            private string levelField;

            private string technologiesField;

            private string typeField;

            private string deliveryMethodField;

            private object referenceMaterialsField;

            /// <remarks/>
            public string CourseLength
            {
                get
                {
                    return this.courseLengthField;
                }
                set
                {
                    this.courseLengthField = value;
                }
            }

            /// <remarks/>
            public string PublishedDate
            {
                get
                {
                    return this.publishedDateField;
                }
                set
                {
                    this.publishedDateField = value;
                }
            }

            /// <remarks/>
            public string Language
            {
                get
                {
                    return this.languageField;
                }
                set
                {
                    this.languageField = value;
                }
            }

            /// <remarks/>
            public string Audiences
            {
                get
                {
                    return this.audiencesField;
                }
                set
                {
                    this.audiencesField = value;
                }
            }

            /// <remarks/>
            public string Level
            {
                get
                {
                    return this.levelField;
                }
                set
                {
                    this.levelField = value;
                }
            }

            /// <remarks/>
            public string Technologies
            {
                get
                {
                    return this.technologiesField;
                }
                set
                {
                    this.technologiesField = value;
                }
            }

            /// <remarks/>
            public string Type
            {
                get
                {
                    return this.typeField;
                }
                set
                {
                    this.typeField = value;
                }
            }

            /// <remarks/>
            public string DeliveryMethod
            {
                get
                {
                    return this.deliveryMethodField;
                }
                set
                {
                    this.deliveryMethodField = value;
                }
            }

            /// <remarks/>
            public object ReferenceMaterials
            {
                get
                {
                    return this.referenceMaterialsField;
                }
                set
                {
                    this.referenceMaterialsField = value;
                }
            }
        }

        /// <remarks/>

        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class CourseDetailsRequirements
        {

            private string systemField;

            private string accessibilityField;

            /// <remarks/>
            public string System
            {
                get
                {
                    return this.systemField;
                }
                set
                {
                    this.systemField = value;
                }
            }

            /// <remarks/>
            public string Accessibility
            {
                get
                {
                    return this.accessibilityField;
                }
                set
                {
                    this.accessibilityField = value;
                }
            }
        }

        /// <remarks/>       
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class CourseDetailsAssessment
        {

            private string detailsField;

            private string idField;

            /// <remarks/>
            public string Details
            {
                get
                {
                    return this.detailsField;
                }
                set
                {
                    this.detailsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }
        }



        public class Course
        {
            [JsonProperty("CourseTitle")]
            public string CourseTitle { get; set; }
            [JsonProperty("DoesUserHaveAccessToCourse")]
            public bool DoesUserHaveAccessToCourse { get; set; }
            [JsonProperty("ExpirationDate")]
            public object ExpirationDate { get; set; }
            [JsonProperty("InstructorDisplayNames")]
            public List<object> InstructorDisplayNames { get; set; }
            [JsonProperty("IsRegisteredForLiveEvent")]
            public bool IsRegisteredForLiveEvent { get; set; }
            [JsonProperty("IsVersionModified")]
            public bool IsVersionModified { get; set; }
            [JsonProperty("LastAccessedDate")]
            public object LastAccessedDate { get; set; }
            [JsonProperty("PackageLanguageCode")]
            public string PackageLanguageCode { get; set; }
            [JsonProperty("PercentModulesComplete")]
            public int PercentModulesComplete { get; set; }
            [JsonProperty("ProductPackageVersionStatusID")]
            public int ProductPackageVersionStatusID { get; set; }
            [JsonProperty("PublishedDate")]
            public DateTime PublishedDate { get; set; }
            [JsonProperty("PublishedVersion")]
            public string PublishedVersion { get; set; }
            [JsonProperty("ReplacementCourseTitle")]
            public object ReplacementCourseTitle { get; set; }
            [JsonProperty("ReplacementProductID")]
            public int ReplacementProductID { get; set; }
            [JsonProperty("ReplacementProductImageUrl")]
            public object ReplacementProductImageUrl { get; set; }
            [JsonProperty("ReplacementProductInstructors")]
            public object ReplacementProductInstructors { get; set; }
            [JsonProperty("ReplacementProductLanguageCode")]
            public object ReplacementProductLanguageCode { get; set; }
            [JsonProperty("ReplacementProductLanguageID")]
            public int ReplacementProductLanguageID { get; set; }
            [JsonProperty("ReplacementProductLevel")]
            public object ReplacementProductLevel { get; set; }
            [JsonProperty("ReplacementProductPublishedDate")]
            public object ReplacementProductPublishedDate { get; set; }
            [JsonProperty("ReplacementProductShortDescription")]
            public object ReplacementProductShortDescription { get; set; }
            [JsonProperty("RetirementDate")]
            public object RetirementDate { get; set; }
        }

    }
}
