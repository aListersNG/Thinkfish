﻿Shader "Custom/Vignette"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_VignetteStrength("VignetteStrength", float) = 0.5
		_FocusPointX("FocusPointX", float) = 0.5
		_FocusPointY("FocusPointY", float) = 0.5
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			float _VignetteStrength;
			float _FocusPointX;
			float _FocusPointY;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 nCoord = i.vertex.xy / _ScreenParams.xy;
				fixed4 col = tex2D(_MainTex, nCoord);
				
				//Move it to the selected object
				float2 centeredCoord = nCoord - 1.0f;
				centeredCoord.x += 1.0f - _FocusPointX;
				centeredCoord.y += _FocusPointY;

				float dist = sqrt(dot( centeredCoord, centeredCoord));

				float vig = dist * _VignetteStrength;

				return fixed4(lerp(col, fixed4(0.0f,0.0f,0.0f,0.5f), vig));


				//return fixed4(lerp(editCol, col, 1.0f));
			}
			ENDCG
		}
	}
}
