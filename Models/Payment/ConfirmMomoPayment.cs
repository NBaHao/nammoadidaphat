﻿using CoolMate.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CoolMate.Models.Payment
{
    [BindProperties]
    public class ConfirmMomoPayment
    {
        public string? partnerCode { get; set; } = string.Empty;
        public string? orderId { get; set; } = string.Empty;
        public string? requestId { get; set; } = string.Empty;
        public long amount { get; set; }
        public string? orderInfo { get; set; } = string.Empty;
        public string? orderType { get; set; } = string.Empty;
        public long transId { get; set; } 
        public int resultCode { get; set; }
        public string? message { get; set; } = string.Empty;
        public string? payType { get; set; } = string.Empty;
        public long responseTime { get; set; }
        public string? extraData { get; set; } = string.Empty;
        public string? signature { get; set; } = string.Empty;

        public bool IsValidSignature()
        {
            var accessKey = "F8BBA842ECF85";
            var secretKey = "K951B6PE1waDMi640xX08PD3vg6EkVlz";
            var rawHash = "accessKey=" + accessKey +
                   "&amount=" + this.amount +
                   "&extraData=" + this.extraData +
                   "&message=" + this.message +
                   "&orderId=" + this.orderId +
                   "&orderInfo=" + this.orderInfo +
                   "&orderType=" + this.orderType +
                   "&partnerCode=" + this.partnerCode +
                   "&payType=" + this.payType +
                   "&requestId=" + this.requestId +
                   "&responseTime=" + this.responseTime +
                   "&resultCode=" + this.resultCode +
                   "&transId=" + this.transId;
            var checkSignature = HashHelper.HmacSHA256(rawHash, secretKey);
            return this.signature.Equals(checkSignature);
        }
    }
}
