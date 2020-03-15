Shader "Custom/MonoTone" {
	Properties {
		_MainTex("MainTex", 2D) = ""{}
		_Value("_Mono", Range(0,1)) = 1
	}
	SubShader {
		Pass {
			CGPROGRAM

			#include "UnityCG.cginc"

			#pragma vertex vert_img
			#pragma fragment frag

			float _Value;
			sampler2D _MainTex;

			fixed4 frag(v2f_img i) : COLOR {
				fixed4 c = tex2D(_MainTex, i.uv);
				float gray = c.r * 0.3 + c.g * 0.6 + c.b * 0.1;
				c.rgb = lerp(fixed3(gray, gray, gray), c.rgb, _Value);
				return c;
			}

			ENDCG
		}
	}
}