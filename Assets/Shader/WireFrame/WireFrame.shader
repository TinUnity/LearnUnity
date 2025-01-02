Shader "Custom/WireFrame"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _LineColor ("LineColor", Color) = (1,1,1,1)
        _LineSize ("LineSize", Float) = 0.1
        _ParcelSize ("ParcelSize", Range(0, 100)) = 1
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        fixed4 _Color;
        fixed4 _LineColor;
        float _LineSize;
        float _ParcelSize;
        
        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };
        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            half val1 = step(_LineSize * 2, frac(IN.worldPos.x / _ParcelSize) + _LineSize);
            half val2 = step(_LineSize * 2, frac(IN.worldPos.z / _ParcelSize) + _LineSize);
            fixed val = 1 - (val1 * val2);
            o.Albedo = lerp(_Color, _LineColor, val);
            o.Alpha = 1;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
