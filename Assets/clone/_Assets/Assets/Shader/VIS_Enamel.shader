Shader "VIS/Enamel" {
	Properties {
		_Color ("Main Color", Vector) = (1,1,1,1)
		_MainTex ("Base Texture (RGB)", 2D) = "white" {}
		_CubeTex ("Reflection Cubemap", Cube) = "" {}
		_BlendFactor ("Blend Factor", Range(0, 1)) = 0.5
		_FresnelPower ("Fresnel Power", Range(0.05, 5)) = 0.75
		_EmissionFactor ("Emission Factor", Range(0, 1)) = 0.5
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Reflective/VertexLit"
}