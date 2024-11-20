using AbrPlus.Integration.OpenCRM.Requests;
using AbrPlus.Integration.OpenCRM.Responses;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Mappers
{
    public static class CallStoreMapper
    {
        public static CallCreateResponse ToResponse(this CallCreateRequest request)
        {
            if (request == null)
            {
                return null;
            }
            return new CallCreateResponse
            {
                CallId = request.SourceCallId,
                InitCallChannelId = request.SourceInitCallChannelId,
            };
        }
        public static CallUpdateResponse ToResponse(this CallUpdateRequest request)
        {
            if (request == null)
            {
                return null;
            }
            return new CallUpdateResponse
            {
                IdentityId = request.IdentityId,
            };
        }
        public static CallChannelCreateResponse ToResponse(this CallChannelCreateRequest request)
        {
            if (request == null)
            {
                return null;
            }
            return new CallChannelCreateResponse
            {
                CallChannelId = request.SourceCallChannelId,
            };
        }
        public static CallChannelUpdateResponse ToResponse(this CallChannelUpdateRequest request)
        {
            if (request == null)
            {
                return null;
            }
            return new CallChannelUpdateResponse
            {
                CallChannelId = request.ChannelId,
            };
        }
        public static MergeCallResponse ToResponse(this MergeCallRequest request)
        {
            if (request == null)
            {
                return null;
            }
            return new MergeCallResponse
            {
                Merged = true,
            };
        }
    }
}
