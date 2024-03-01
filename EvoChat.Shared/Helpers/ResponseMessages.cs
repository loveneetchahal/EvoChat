using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoChat.Shared.Helpers
{
    public static class ResponseMessages
    {
        public static readonly string msgUserRegisterSuccess = "User registered succesfully";
        public static readonly string msgManualUserRegisterSuccess = "User registered succesfully. please check your email to confirm your email";
        public static readonly string msgUserRoleNotAuthorized = "Requested user type is not authorized";
        public static readonly string msgSomethingWentWrong = "Something went wrong. ";
        public static readonly string msgParametersNotCorrect = "Parameters are not correct";
        public static readonly string msgCouldNotFoundAssociatedUser = "Could not found any user associated with this email";
        public static readonly string msgUserBlockedOrDeleted = "User blocked or deleted. please contact to administrator";
        public static readonly string msgEmailNotConfirmed = "Email not confirmed";
        public static readonly string msgUserLoginSuccess = "User login successfully";
        public static readonly string msgInvalidCredentials = "Username or Password is incorrect";
        public static readonly string msgAccountNotFound = "This account cannot be found. Please use a different account or sign up for a new account";
        public static readonly string msgEmailConfirmationSuccess = "Email confirmed successfully";
        public static readonly string msgConfirmationCodeSentSuccess = "Confirmation code sent on your email";
        public static readonly string msgInvalidOTP = "Otp is Invalid";
        public static readonly string msgOTPSentSuccess = "Otp sent on your email";
        public static readonly string msgLinkSentSuccess = "Reset password link sent on your email. please check your email to reset your password";
        public static readonly string msgPasswordResetSuccess = "Password reset successfully";
        public static readonly string msgPasswordChangeSuccess = "Password changed successfully";
        public static readonly string msgEmailAlreadyConfirmed = "Email already confirmed";
        public static readonly string msgResetEmailOtpSendSuccess = "Reset email OTP sent on your both emails";
        public static readonly string msgNewOldOtpInvalid = "Either new or old email otp is invalid";
        public static readonly string msgEmailAlreadyUsed = "The provided email already in used. please try with other email";
        public static readonly string msgEmailResetSuccess = "Email reset successfully. Please login with new email";
        public static readonly string msgLogoutSuccess = "User logout successfully";
        public static readonly string msgDbConnectionError = "Database connection error";
        public static readonly string msgBlockOrInactiveUserNotPermitted = "Block or inactive user can't update detials";
        public static readonly string msgSessionExpired = "Your current session has expired. Please login again to keep all your service working";
        public static readonly string msgTokenExpired = "Access token is expired";
        public static readonly string msgSamePasswords = "OldPassword and NewPassword cannot be same";
        public static readonly string msgVerifiedUser = "You are verified successfully";
        public static readonly string msgProfilePicUpdated = "Profile picture updated successfully";
        public static readonly string msgInvalidUserRole = "Invalid user role.";  
        public static readonly string msgCreationSuccess = " created successfully";
        public static readonly string msgUpdationSuccess = " updated successfully";
        public static readonly string msgFoundSuccess = " found successfully";
        public static readonly string msgShownSuccess = " shown successfully";
        public static readonly string msgGotSuccess = "data shown successfully";
        public static readonly string msgNotFound = "could not found any ";
        public static readonly string msgListFoundSuccess = " list shown successfully";
        public static readonly string msgDeletionSuccess = " deleted successfully";
        public static readonly string msgAlreadyExists = " already exists";
        public static readonly string msgAccountAlreadyExists = "an account has been already used, please sign in";
        public static readonly string msgAlreadyDeleted = " already deleted so you can't updated it.";
        public static readonly string msgAdditionSuccess = " added Successfully";
        public static readonly string msgRemovedSuccess = " removed Successfully"; 
        public static readonly string msgAppliedSuccess = " applied Successfully";
        public static readonly string msgRechargeSuccess = "Recharge done Successfully";
        public static readonly string msgPaymentFailed = "Payment Failed";
        public static readonly string msgReportLead48hours = "You can report it within 48 hours after assignment";
        public static readonly string msgLeadAlreadyReported = "Lead already reported. ";
        public static readonly string msgInvalidProvider = "Invalid provider";
        public static readonly string msgInvalidToken = "Invalid provided token";
        public static readonly string msgUserAlreadyActive = "Your account is already active.";
    }
}
