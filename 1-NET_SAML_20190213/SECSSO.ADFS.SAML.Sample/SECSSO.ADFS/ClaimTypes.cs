namespace SECSSO.ADFS
{
	public static class ClaimTypes
	{
		//
		// 요약:
		//     인증 되었으면 엔터티를 지정 하는 클레임에 대 한 URI http://schemas.microsoft.com/ws/2008/06/identity/claims/authenticationinstant
		//     합니다.
		public const string AuthenticationInstant = "http://schemas.microsoft.com/ws/2008/06/identity/claims/authenticationinstant";
		//
		// 요약:
		//     엔터티의 거부 전용 보안 식별자 (SID)를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/denyonlysid입니다.
		//     거부 전용 SID는 보안 가능한 개체에 대해 지정된 엔터티를 거부합니다.
		public const string DenyOnlySid = "http://schemas.sec.com/2018/05/identity/claims/denyonlysid";

		//
		// 요약:
		//     엔터티의 전자 메일 주소를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/LoginId
		//     합니다.
		public const string LoginID = "http://schemas.sec.com/2018/05/identity/claims/LoginId";

		//
		// 요약:
		//     엔터티의 전자 메일 주소를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/email
		//     합니다.
		public const string Email = "http://schemas.sec.com/2018/05/identity/claims/Mail";
		//
		// 요약:
		//     엔터티의 전자 메일 주소를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/Username
		//     합니다.
		public const string UserName = "http://schemas.sec.com/2018/05/identity/claims/Username";
		//
		// 요약:
		//     엔터티의 성별을 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/gender입니다.
		public const string Gender = "http://schemas.sec.com/2018/05/identity/claims/gender";
		//
		// 요약:
		//     엔터티의 이름을 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname입니다.
		public const string GivenName = "http://schemas.sec.com/2018/05/identity/claims/givenname";
		//
		// 요약:
		//     해시 값을 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/hash입니다.
		public const string Hash = "http://schemas.sec.com/2018/05/identity/claims/hash";
		//
		// 요약:
		//     엔터티의 집 전화 번호를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/homephone입니다.
		public const string HomePhone = "http://schemas.sec.com/2018/05/identity/claims/homephone";
		//
		// 요약:
		//     지정 된 엔터티가 있는 로캘을, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/locality
		//     하는 클레임에 대 한 URI입니다.
		public const string Locality = "http://schemas.sec.com/2018/05/identity/claims/locality";
		//
		// 요약:
		//     엔터티의 휴대폰 번호를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone입니다.
		public const string MobilePhone = "http://schemas.sec.com/2018/05/identity/claims/mobilephone";
		//
		// 요약:
		//     엔터티의 이름을 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name입니다.
		public const string Name = "http://schemas.sec.com/2018/05/identity/claims/name";
		//
		// 요약:
		//     엔터티의 이름을 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier입니다.
		public const string NameIdentifier = "http://schemas.sec.com/2018/05/identity/claims/nameidentifier";
		//
		// 요약:
		//     엔터티의 대체 전화 번호를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/otherphone입니다.
		public const string OtherPhone = "http://schemas.sec.com/2018/05/identity/claims/otherphone";
		//
		// 요약:
		//     엔터티의 우편 번호를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/postalcode입니다.
		public const string PostalCode = "http://schemas.sec.com/2018/05/identity/claims/postalcode";
		//
		// 요약:
		//     RSA 키, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/rsa를 지정 하는 클레임에
		//     대 한 URI입니다.
		public const string Rsa = "http://schemas.sec.com/2018/05/identity/claims/rsa";
		//
		// 요약:
		//     보안 식별자 (SID)를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid입니다.
		public const string Sid = "http://schemas.sec.com/2018/05/identity/claims/sid";
		//
		// 요약:
		//     서비스 사용자 이름 (SPN)을 지정 하는 클레임에 대 한 URI 클레임 http://schemas.xmlsoap.org/ws/2005/05/identity/claims/spn입니다.
		public const string Spn = "http://schemas.sec.com/2018/05/identity/claims/spn";
		//
		// 요약:
		//     시 /도 엔터티 상주 하 http://schemas.xmlsoap.org/ws/2005/05/identity/claims/stateorprovince를
		//     지정 하는 클레임에 대 한 URI입니다.
		public const string StateOrProvince = "http://schemas.sec.com/2018/05/identity/claims/stateorprovince";
		//
		// 요약:
		//     엔터티의 주소를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/streetaddress입니다.
		public const string StreetAddress = "http://schemas.sec.com/2018/05/identity/claims/streetaddress";
		//
		// 요약:
		//     엔터티의 성을 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname입니다.
		public const string Surname = "http://schemas.sec.com/2018/05/identity/claims/surname";
		//
		// 요약:
		//     시스템 엔터티를 식별 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/system입니다.
		public const string System = "http://schemas.sec.com/2018/05/identity/claims/system";
		//
		// 요약:
		//     지문을 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/thumbprint입니다.
		//     지문은 X.509 인증서의 고유한 전역 SHA-1 해시입니다.
		public const string Thumbprint = "http://schemas.sec.com/2018/05/identity/claims/thumbprint";
		//
		// 요약:
		//     사용자 계정 이름 (UPN)를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn입니다.
		public const string Upn = "http://schemas.sec.com/2018/05/identity/claims/upn";
		//
		// 요약:
		//     URI를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/uri입니다.
		public const string Uri = "http://schemas.sec.com/2018/05/identity/claims/uri";
		//
		// 요약:
		//     엔터티의 웹 페이지, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/webpage를 지정하는
		//     클레임에 대한 URI입니다.
		public const string Webpage = "http://schemas.sec.com/2018/05/identity/claims/webpage";
		//
		// 요약:
		//     DNS 이름을 지정 하는 클레임에 대 한 URI 컴퓨터 이름이 나 연결 된 X.509 인증서의 발급자 또는 주체의 대체 이름과 http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dns입니다.
		public const string Dns = "http://schemas.sec.com/2018/05/identity/claims/dns";
		//
		// 요약:
		//     엔터티의 생년월일을 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth입니다.
		public const string DateOfBirth = "http://schemas.sec.com/2018/05/identity/claims/dateofbirth";
		//
		// 요약:
		//     엔터티 상주 하 http://schemas.xmlsoap.org/ws/2005/05/identity/claims/country 국가/지역을
		//     지정 하는 클레임에 대 한 URI입니다.
		public const string Country = "http://schemas.sec.com/2018/05/identity/claims/country";
		//
		// 요약:
		//     엔터티에 대 한 권한 부여 결정을 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision입니다.
		public const string AuthorizationDecision = "http://schemas.sec.com/2018/05/identity/claims/authorizationdecision";
		//
		// 요약:
		//     엔터티가 인증 되었으면 하는 방법을 지정 하는 클레임에 대 한 URI http://schemas.microsoft.com/ws/2008/06/identity/claims/authenticationmethod
		//     합니다.
		public const string AuthenticationMethod = "http://schemas.microsoft.com/ws/2008/06/identity/claims/authenticationmethod";
		//
		// 요약:
		//     쿠키; 경로 지정 하는 클레임에 대 한 URI http://schemas.microsoft.com/ws/2008/06/identity/claims/cookiepath
		//     합니다.
		public const string CookiePath = "http://schemas.microsoft.com/ws/2008/06/identity/claims/cookiepath";
		//
		// 요약:
		//     엔터티의; 거부 전용 주 SID를 지정 하는 클레임에 대 한 URI http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarysid
		//     합니다. 거부 전용 SID는 보안 가능한 개체에 대해 지정된 엔터티를 거부합니다.
		public const string DenyOnlyPrimarySid = "http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarysid";
		//
		// 요약:
		//     엔터티의; 거부 전용 주 그룹 SID를 지정 하는 클레임에 대 한 URI http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarygroupsid
		//     합니다. 거부 전용 SID는 보안 가능한 개체에 대해 지정된 엔터티를 거부합니다.
		public const string DenyOnlyPrimaryGroupSid = "http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarygroupsid";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlywindowsdevicegroup
		//     합니다.
		public const string DenyOnlyWindowsDeviceGroup = "http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlywindowsdevicegroup";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/dsa 합니다.
		public const string Dsa = "http://schemas.microsoft.com/ws/2008/06/identity/claims/dsa";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/expiration 합니다.
		public const string Expiration = "http://schemas.microsoft.com/ws/2008/06/identity/claims/expiration";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/expired 합니다.
		public const string Expired = "http://schemas.microsoft.com/ws/2008/06/identity/claims/expired";
		//
		// 요약:
		//     엔터티, 그룹에 대 한 SID를 지정 하는 클레임에 대 한 URI http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid
		//     합니다.
		public const string GroupSid = "http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/ispersistent 합니다.
		public const string IsPersistent = "http://schemas.microsoft.com/ws/2008/06/identity/claims/ispersistent";
		//
		// 요약:
		//     주를 지정 하는 클레임에 대 한 URI의 그룹 SID 엔터티, http://schemas.microsoft.com/ws/2008/06/identity/claims/primarygroupsid
		//     합니다.
		public const string PrimaryGroupSid = "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarygroupsid";
		//
		// 요약:
		//     X.509 인증서의 고유 이름 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/x500distinguishedname
		//     합니다. X.500 표준은 X.509 인증서에서 사용 되는 고유 이름을 정의 하는 방법을 정의 합니다.
		public const string X500DistinguishedName = "http://schemas.sec.com/2018/05/identity/claims/x500distinguishedname";
		//
		// 요약:
		//     엔터티를 주 SID를 지정 하는 클레임에 대 한 URI http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid
		//     합니다.
		public const string PrimarySid = "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid";
		//
		// 요약:
		//     직렬 번호, http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber를
		//     지정 하는 클레임에 대 한 URI입니다.
		public const string SerialNumber = "http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata 합니다.
		public const string UserData = "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/version 합니다.
		public const string Version = "http://schemas.microsoft.com/ws/2008/06/identity/claims/version";
		//
		// 요약:
		//     엔터티를 Windows 도메인 계정 이름을 지정 하는 클레임에 대 한 URI http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsaccountname
		//     합니다.
		public const string WindowsAccountName = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsaccountname";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsdeviceclaim 합니다.
		public const string WindowsDeviceClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsdeviceclaim";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsdevicegroup 합니다.
		public const string WindowsDeviceGroup = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsdevicegroup";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsuserclaim 합니다.
		public const string WindowsUserClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsuserclaim";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsfqbnversion 합니다.
		public const string WindowsFqbnVersion = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsfqbnversion";
		//
		// 요약:
		//     http://schemas.microsoft.com/ws/2008/06/identity/claims/windowssubauthority 합니다.
		public const string WindowsSubAuthority = "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowssubauthority";
		//
		// 요약:
		//     익명 사용자를 지정 하는 클레임에 대 한 URI http://schemas.xmlsoap.org/ws/2005/05/identity/claims/anonymous입니다.
		public const string Anonymous = "http://schemas.sec.com/2018/05/identity/claims/anonymous";
		//
		// 요약:
		//     Id가 인증 되는지 여부에 대 한 세부 정보를 지정 하는 클레임에 대 한 URI, http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authenticated
		//     합니다.
		public const string Authentication = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authentication";
		//
		// 요약:
		//     엔터티의 역할을 지정 하는 클레임에 대 한 URI http://schemas.microsoft.com/ws/2008/06/identity/claims/role
		//     합니다.
		public const string Role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
		//
		// 요약:
		//     http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor 합니다.
		public const string Actor = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor";
	}
}
