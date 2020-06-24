using System;

// https://community.sonarsource.com/t/the-parameter-is-not-declared-in-the-argument-list-help-wanted/26601

namespace Namespace
{
    public enum ReasonCode
    {
        Unknown,
        NotFurtherSpecified,
        SemanticError,
        UnknownAccount,
        Ok,
        OkWithRemarks,
    }

    public static class Repro
    {
        public static string Go() =>
            AsCode(ReasonCode.Ok) + AsCode2(ReasonCode.Ok);

        static string AsCode(ReasonCode reasonCode) =>
            reasonCode switch
            {
                ReasonCode.Unknown => "0",
                ReasonCode.NotFurtherSpecified => "NotSpecified",
                ReasonCode.SemanticError => "Semantic",
                ReasonCode.UnknownAccount => "Unknown Account",
                ReasonCode.Ok => "Ok",
                ReasonCode.OkWithRemarks => "Ok with remarks",
                _ => throw new ArgumentException("invalid enum value", nameof(reasonCode)),
            };

        static string AsCode2(ReasonCode reasonCode)
        {
            var code = ReasonCode.Ok;
            return reasonCode switch
            {
                ReasonCode.Unknown => "0",
                ReasonCode.NotFurtherSpecified => "NotSpecified",
                ReasonCode.SemanticError => "Semantic",
                ReasonCode.UnknownAccount => "Unknown Account",
                ReasonCode.Ok => "Ok",
                ReasonCode.OkWithRemarks => "Ok with remarks",
                _ => throw new ArgumentException("invalid enum value", nameof(code)), // True Positive
            };
        }
    }
}