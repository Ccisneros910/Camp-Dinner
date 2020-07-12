Shader "Hidden/PP"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Redness ("Redness", Range(-1,1)) = 0 
        _Greenness("Greenness", Range(-1,1)) = 0
        _Blueness("Blueness", Range(-1,1)) = 0
        _Transparency("Transparency", Range(-1,1)) = 0
    }
    SubShader
    {
         Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
          
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
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Redness;
            float _Greenness;
            float _Blueness;
            float _Transparency;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                col.r += _Redness;
                col.g += _Greenness;
                col.b += _Blueness;
                col.a = _Transparency;
                return col;
            }
            ENDCG
        }
    }
}
