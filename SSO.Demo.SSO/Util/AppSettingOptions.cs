namespace SSO.Demo.SSO.Util
{
    /// <summary>
    /// 应用配置信息
    /// </summary>
    public class AppSettingOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public List<AppHSSetting> appHSSettings { get; set; }
        public List<AppRSSetting> appRSSettings { get; set; } = RSAKey.InitKey();
    }
    /// <summary>
    /// 应用配置-对称加密方式
    /// </summary>
    public class AppHSSetting
    {
        /// <summary>
        /// 应用域名
        /// </summary>
        public string domain { get; set; }
        /// <summary>
        /// 应用Key
        /// </summary>
        public string clientId { get; set; }
        /// <summary>
        /// 应用密钥
        /// </summary>
        public string clientSecret { get; set; }
    }
    /// <summary>
    /// 应用配置-非对称加密
    /// </summary>
    public class AppRSSetting
    {
        /// <summary>
        /// 应用域名
        /// </summary>
        public string domain { get; set; }
        /// <summary>
        /// 应用Key
        /// </summary>
        public string clientId { get; set; }
        /// <summary>
        /// 公钥-加密
        /// </summary>
        public string publicKey { get; set; }
        /// <summary>
        /// 私钥-解密
        /// </summary>
        public string privateKey { get; set; }
    }
    public class RSAKey
    {
        //真实项目存数据库
        public static List<AppRSSetting> InitKey()
        {
            return new List<AppRSSetting>()
            {
                new AppRSSetting()
                {
                    domain="localhost:7001",
                    clientId="web1",
                    publicKey=@"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAvnZdjDT+SFgdZJiV8XcC
dvWck3OenzcQme+mfpoJtDIoUgJYmpoTLRA+wH8t21MFTz6e69oC3SKq7dx/xvsa
5xRBud0oNwRRSKnUF345R84qTC2mvrznXNuiIuOJV2soG/lVxwCDgVPh0yJnWWkd
3wD8D3keIpyxC5eHE5RnwVnB0paxk5Mnu/E/SmIoxdt1xR3sAg8nspbfMa3Wswhk
/jKZx2GPjYGunK7epysr2gkVekhX7S4o7dfuFK3x/+wG+mdsNFVsp8eQ+G66rHPP
i50eeKTUCH1RneSCyxVV8EZflVYHWX7azCW4AOsqEQGqMWvwshi09BVo2O8hHrnL
cwIDAQAB",
                    privateKey=@"MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC+dl2MNP5IWB1k
mJXxdwJ29ZyTc56fNxCZ76Z+mgm0MihSAliamhMtED7Afy3bUwVPPp7r2gLdIqrt
3H/G+xrnFEG53Sg3BFFIqdQXfjlHzipMLaa+vOdc26Ii44lXaygb+VXHAIOBU+HT
ImdZaR3fAPwPeR4inLELl4cTlGfBWcHSlrGTkye78T9KYijF23XFHewCDyeylt8x
rdazCGT+MpnHYY+Nga6crt6nKyvaCRV6SFftLijt1+4UrfH/7Ab6Z2w0VWynx5D4
brqsc8+LnR54pNQIfVGd5ILLFVXwRl+VVgdZftrMJbgA6yoRAaoxa/CyGLT0FWjY
7yEeuctzAgMBAAECggEAczlonsnwjBPCtHkbPVmiRBWTBCGOdQP7JyW0tCK8fCdb
/UEuGVndAAYz8IEAXQ98xtQ7kLPzx5SRlBUxuE9xlxrKKIeDLMWP50XW6d+TB73S
GQQFPJ9L2QGGtVSyYhCR01qkaiAFbtgwZmsJ2y2cxKzz0OiVMptZAIpLTa0al/2I
s+jtFs8rAgCfduUfLtwIX+fNG9Bw2oPgLbU0OPVObBSCjAMqv3/7mGeXG6RSzW24
lInMdEU4gzPBpEGVy+1PkwfEhlGBXn45TpOc9V76CE8+8x+5KO1Gjde+Pb7I+ash
gLfja8VfnfgUBebHyykINV0bU2SesG6huoGtjW6IAQKBgQDzYL3KNWXO7u/tcczN
FszTwDju8d9x/OAK8omaS/e+Deot827FVEkiYYfQ3jK6qNcpSgpx2HHKDuZqjVGW
RBWjhCWuRIKguYUltOL0UvF8rBTsWHTAF5hF9dUgFZBIsZk04O9FTkvye5sSDXKE
uJO0XRBPiSU7mmHuazzAIouL4QKBgQDIVxRnRCrbEOhPNvp1YdAVi4FQg37DRqBX
itUWtOYKhQdy2X19jQniO8B4lfcb82mrtX7FPb0dUYmNtGH5tZ5sjQpsO02vUGfe
rkjBihcyLjGTbXi6a2C1vBzxwbq6pXFHWR5qNRXoSwQ675Q+ilKPxT2P53QUl2TY
lmDrUl2h0wKBgAwVg5bkq9doebU6b0bHmQfyhWEn1UZdneotPLPSjcx7+GKrsZZO
pwrz+MBgJ/iopXZBXN9mNdAoiTxFJAXn/4MM7qoGcM32KCxFHPewnpjoGmnZwoI/
KapfmGNtbqqNVuQPPxIb3x19EagFzufUGlFcRZENaDHban1iCbQogvFBAoGBAJ8t
CQoPkFlkMqAV16QCJlmn8QPupn4zFFzZ8vrKmmhLUCLBiUKDGBJHVWK6DI+JtDD4
0JOYvTSZP0h2xM2prwkieuCJseyUXyL/qNEVjd6R81Pmy+CaRkm+/+RZ/6oin0GI
HnFWYmShjefhyRBzyKtwlLxMst9Vdovb13/BfqF/AoGADfPeU1I/SarCaymMcb6P
xfV/3kKJW1673hvzDGiVuDYjUWa8j9h9bowi6lHjsUbjw4vT/lfU3+5TaXeTdmLF
FhQqU7Gw31IkWUw8nQg9V5rdoJui8Z2MKpLeo/DeGrkk8QVn2/GNUiR+DLGHOK2M
yPUFayuJ1n+agcS5nInFQiU="

                },
                new AppRSSetting()
                {
                    domain="localhost:7001",
                    clientId="web2",
                    publicKey=@"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnW5RiFnRO7JWqbP61BG7
ojQ3wN8q0W95k2hKH3p6dXqdL49LvNbm2KjiCKJYQCb2TepZFj0gEdG0HhgNdhxY
T6Hf4GQPxnz53vQdh8+GLxElFHsXk0GTrIKltWdeDb3VVNhBFlU4/afxsH7r6dUI
apW2sL+N3VFtb9uztIeh1koiotIgEwePewMpeQd4QAT+C38lH7UNQWyR8e8HYENX
suBZO5Nt45VGHuxC4BV0BeBYEO5mYMuAcrGQxdwKhZZzNZ5zFbXpE7UDyXd+zUbP
CurUN++gTchqTkI4pksqxIW/8cU7CD9FsGEgN/gBugRyqXIpl/gaztIBntopLhsn
WQIDAQAB",
                    privateKey=@"MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCdblGIWdE7slap
s/rUEbuiNDfA3yrRb3mTaEofenp1ep0vj0u81ubYqOIIolhAJvZN6lkWPSAR0bQe
GA12HFhPod/gZA/GfPne9B2Hz4YvESUUexeTQZOsgqW1Z14NvdVU2EEWVTj9p/Gw
fuvp1Qhqlbawv43dUW1v27O0h6HWSiKi0iATB497Ayl5B3hABP4LfyUftQ1BbJHx
7wdgQ1ey4Fk7k23jlUYe7ELgFXQF4FgQ7mZgy4BysZDF3AqFlnM1nnMVtekTtQPJ
d37NRs8K6tQ376BNyGpOQjimSyrEhb/xxTsIP0WwYSA3+AG6BHKpcimX+BrO0gGe
2ikuGydZAgMBAAECggEBAJXY56pNM6cKvQqS0XEB4AMoiNkAkpT+8k2ousTzo5Qm
vW8DiieYteoL9foZ7L5DV7YaFenhDKFpZXQvmMCPgk9p2NqQ46MeWggpe+JFWYd7
Xjv8XhhAFvvg7zGXziJuSpyTqoBDZheqv5YreQn9SCGLl3TtH29FjlEmYgq3/wcj
0wrAfkWxPFKoZj0d9+HnShB9nzQ560PCnq/U08G3QPtsWgc5VSTZm/0aNX1QCm2j
pO/xebL9xitmNfg2noaS5Fpk1cUU0Qe6ww/ArlU/FmBFhLBLYtOdbh1cMDd7Wdbq
7Quu6hePvBsChiKt726tNEZdIC8DPh/y03zmtGS0SvECgYEA0UqqURs0k1+DLRDa
9xOMWDA5GvyL204BycGz8VBCBvl9Xo/zaxTpAjX7bLh/IksMIjKc5NMw0VATT+Mg
b1AQHqDmm82uedruf+Fj/1Gj+7nalAr/23wwpBIgTZRGdeN+ejpuDOdtDkavaNYr
1k00pvjh3M+7umlUnurCcwm3Uo8CgYEAwJC5rCyzWASyIbaS0YMEbRezTXMmLT/G
PTzGNZpLJClVwjxQZOn16xMN0NJRlqsHWcEjWvVWB5f4nYIsod5vQSwprpAhvWga
LHeZHJq4oHbJae3eLMx4XUdu7vIf823jBuqGOENJR5IlzVuCliwylqtarSg4QGfq
VnE08TUlu5cCgYB9GTkmk7FgaZXZ6RpI1zlrOR/ZHp1mL4FoHE03b3aX/qbOUBL6
rZv9Q1EOklUDpYISKtiW+hlS858ngCZSArQv6pMNC+s/UPqAG7QO17jB7TxWgyCe
C+RzHZaLaJaZPqrJ2oUPV4FbKCsO6f138dwH9fnjZ5PZf74h40bpRiR6xwKBgQCt
JLQ+EodDeh1s4MuMZKCjMq8+0W2fO/uUbkPOSKiNoDkDB9ZFlnRO5PgELke8EJXw
Zw/SJkwvUb7yaOyWsvkYAYyM7/3WX3dBSlw6cwfVCFm7zGx7nXIQdT1SzhRafhCm
1FLQ3fdSyh8BUenN+3mVLge/MC28A3OaO/odc+s0iwKBgGLF/oZhw4w2/KdznKCW
BKe9v1X+L00g4mmKr5h0quaaRdrc5akD2lTK+5vlytW3KPoOHdrHS83Th6Yj+MYu
89VTRnovZOy4W/tjW+lGjUi4j53ePD4cnMXDQrEUXxwBlonnsYSlKEJqK+3hwG6V
KirkBdY+3xQoWFyOqk+LHKnn"
                }
            };
        }
    }
}

    
