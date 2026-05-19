using AbrPlus.Integration.OpenCRM.Enums;
using AbrPlus.Integration.OpenCRM.Requests;
using AbrPlus.Integration.OpenCRM.Responses;
using System;

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
                IdentityId = "sample-identity-id",
                IdentityName = "مشتری نمونه"
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
                IdentityName = "مشتری نمونه"
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

        public static SubmitQueueOperatorVotingResponse ToResponse(this SubmitQueueOperatorVotingRequest request)
        {
            return new SubmitQueueOperatorVotingResponse
            {
                Id = Guid.NewGuid().ToString("N"),
            };
        }

        public static SubmitVotingResponse ToResponse(this SubmitVotingRequest request)
        {
            return new SubmitVotingResponse
            {
                Id = Guid.NewGuid().ToString("N"),
            };
        }

        public static UserResponse ToResponse(this UserInfoByIdentityRequest request)
        {
            return new UserResponse
            {
                Id = request.IdentityId,
                IdentityId = request.IdentityId,
                Key = "sample-user-key",
                NickName = "کاربر نمونه",
                Username = "sample.user",
                UserType = UserType.Operator,
            };
        }

        public static IdentityResponse ToResponse(this CustomerRequest request)
        {
            return new IdentityResponse
            {
                Id = string.IsNullOrWhiteSpace(request?.CustomerId) ? Guid.NewGuid().ToString("N") : request.CustomerId,
                NickName = "مشتری نمونه",
                CustomerNumber = request?.CustomerNo,
                Balance = 1250000
            };
        }

        public static IdentityResponse ToResponse(this IdentityByPhoneNumberRequest request)
        {
            return new IdentityResponse
            {
                Id = Guid.NewGuid().ToString("N"),
                NickName = "مشتری نمونه",
                PhoneContacts = new[]
                {
                    new IdentityContactPhoneResponse
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        PhoneNumber = request?.PhoneNumber,
                        PhoneType = "Mobile",
                        IsDefault = true
                    }
                }
            };
        }

        public static IdentityResponse ToResponse(this IdentityByCustomerNumberRequest request)
        {
            return new IdentityResponse
            {
                Id = Guid.NewGuid().ToString("N"),
                NickName = "مشتری نمونه",
                CustomerNumber = request?.CustomerNumber,
                Balance = 1250000
            };
        }

        public static IdentityContractStatusResponse ToResponse(this IdentityContractStatusRequest request)
        {
            return new IdentityContractStatusResponse
            {
                IsValid = true,
            };
        }

        public static MoneyAccountsResponse ToMoneyAccountsResponse()
        {
            var response = new MoneyAccountsResponse();
            response.MoneyAccounts.Add(new MoneyAccountResponse
            {
                Key = "main",
                Name = "حساب اصلی"
            });
            response.MoneyAccounts.Add(new MoneyAccountResponse
            {
                Key = "wallet",
                Name = "کیف پول"
            });
            return response;
        }

        public static BillableObjectTypesResponse ToBillableObjectTypesResponse()
        {
            var response = new BillableObjectTypesResponse();
            response.CRMObjectTypes.Add(new CrmObjectTypeResponse
            {
                Key = "invoice",
                Name = "فاکتور"
            });
            response.CRMObjectTypes.Add(new CrmObjectTypeResponse
            {
                Key = "contract",
                Name = "قرارداد"
            });
            return response;
        }

        public static BillableObjectTypePropsResponse ToResponse(this BillableObjectTypePropsRequest request)
        {
            var response = new BillableObjectTypePropsResponse();
            response.CRMObjectTypes.Add(new CrmObjectTypeResponse
            {
                Key = request?.BillableObjectTypeKey ?? "invoice",
                Name = "نوع آبجکت مالی نمونه"
            });
            return response;
        }

        public static PaymentResponse ToResponse(this PaymentInfoRequest request)
        {
            return new PaymentResponse
            {
                IdentityId = request?.CustomerRequest?.CustomerId,
                Amount = 250000
            };
        }

        public static SendPaymentLinkToUserResponse ToResponse(this SendPaymentLinkToUserRequest request)
        {
            return new SendPaymentLinkToUserResponse
            {
                IsSuccess = true,
                Message = "لینک پرداخت نمونه با موفقیت ارسال شد."
            };
        }

        public static CrmObjectUrlResponse ToResponse(this CrmObjectUrlRequest request)
        {
            // توجه: در نسخه فعلی DTO، فیلدهای CrmObjectUrlResponse به‌صورت public تعریف نشده‌اند.
            // بنابراین در این نمونه فقط یک نمونه خالی برگردانده می‌شود.
            return new CrmObjectUrlResponse();
        }

        public static CardtableResponse ToResponse(this CardtableRequest request)
        {
            return new CardtableResponse
            {
                TotalItemsCount = 1,
                CardtableItems = new[]
                {
                    new CardtableItemResponse
                    {
                        CrmObjectId = Guid.NewGuid().ToString("N"),
                        CrmObjectTypeId = request?.CrmObjectTypeKey,
                        IdentityId = request?.IdentityId,
                        IdentityNickName = "مشتری نمونه",
                        HolderName = "اپراتور نمونه",
                        Subject = "آیتم نمونه کارتابل",
                        StateName = "در حال بررسی",
                        EnterCardtableDate = DateTime.Now,
                        EnterCardtableDatePersian = "1403/01/01",
                        CardtableStatus = CardtableStatus.InCardTable,
                        CrmObjectType = CrmObjectTypes.Task
                    }
                }
            };
        }

        public static UserExtensionResponse ToResponse(this UserExtensionRequest request)
        {
            return new UserExtensionResponse
            {
                Extension = "1001"
            };
        }

        public static UserTelephonySystemResponse ToResponse(this UserExtensionsRequest request)
        {
            return new UserTelephonySystemResponse
            {
                TelephonySystems = new[]
                {
                    new TelephonySystemResponse
                    {
                        Key = "sample-ts",
                        Name = "مرکز تماس نمونه",
                        BrevityName = "SamplePBX",
                        OfficeId = "office-1",
                        ServerAddress = "127.0.0.1",
                        Extensions = new[]
                        {
                            new TelephonySystemExtensionResponse
                            {
                                Id = Guid.NewGuid().ToString("N"),
                                TelephonySystemId = "sample-ts",
                                UserId = "sample-user-id",
                                Username = request?.Username,
                                Name = "داخلی نمونه"
                            }
                        }
                    }
                }
            };
        }

        public static UserExtensionResponse ToResponse(this UserManagerByExtensionRequest request)
        {
            return new UserExtensionResponse
            {
                Extension = "1000"
            };
        }

        public static IdentityBalanceResponse ToBalanceResponse(this CustomerRequest request)
        {
            return new IdentityBalanceResponse
            {
                Balance = 1250000
            };
        }

        public static CreateInvoiceResponse ToResponse(this CreateSalesInvoiceRequest request)
        {
            return new CreateInvoiceResponse
            {
                InvoiceId = string.IsNullOrWhiteSpace(request?.RefId) ? Guid.NewGuid().ToString("N") : request.RefId
            };
        }
    }
}
