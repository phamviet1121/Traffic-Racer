Shader "grassKit/wavingGrass" {
	Properties {
		_Color ("Color", Vector) = (1,1,1,1)
		_MainTex ("Albedo (RGB), Alpha(A)", 2D) = "white" {}
		_Cutoff ("Shadows Alpha Cutoff", Range(0, 1)) = 0.5
		_BendByView ("Bend By View", Float) = 0.5
		[Space] _GrassBottom ("Grass Bottom(Y)", Float) = 0
		_GrassTop ("Grass Top(Y)", Float) = 1
		[Space] _WaveSpeed ("Waves Speed", Float) = 2
		_WaveFrequency ("Waves Frequency", Float) = 20
		_WaveAndDistortion ("Waves Distortion", Float) = 0.75
		[Space] _WavingTintLighten ("Waving Tint Lighten", Vector) = (0.5,0.5,0.5,0.5)
		_WavingTintDarken ("Waving Tint Darken", Vector) = (0.5,0.5,0.5,0.5)
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
	Fallback "Legacy Shaders/Transparent/Diffuse"
}