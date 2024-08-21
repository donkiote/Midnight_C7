Shader "Custom/Wireframe"
{
    Properties
    {
        _WireframeColor ("Wireframe Color", Color) = (1,1,1,1)
        _WireframeThickness ("Wireframe Thickness", Range(0, 1)) = 0.01
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma geometry geom
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2g
            {
                float4 vertex : SV_POSITION;
            };

            struct g2f
            {
                float4 vertex : SV_POSITION;
                float3 barycentricCoords : TEXCOORD0;
            };

            float4 _WireframeColor;
            float _WireframeThickness;

            v2g vert (appdata v)
            {
                v2g o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            [maxvertexcount(3)]
            void geom(triangle v2g IN[3], inout TriangleStream<g2f> triStream)
            {
                g2f o;
                o.barycentricCoords = float3(1,0,0);
                o.vertex = IN[0].vertex;
                triStream.Append(o);

                o.barycentricCoords = float3(0,1,0);
                o.vertex = IN[1].vertex;
                triStream.Append(o);

                o.barycentricCoords = float3(0,0,1);
                o.vertex = IN[2].vertex;
                triStream.Append(o);
            }

            fixed4 frag (g2f i) : SV_Target
            {
                float minBary = min(min(i.barycentricCoords.x, i.barycentricCoords.y), i.barycentricCoords.z);
                float delta = fwidth(minBary) * 0.5; // fwidth에 배수를 곱하여 더 넓게 만듦
                float alpha = smoothstep(_WireframeThickness, _WireframeThickness + delta, minBary);
                float4 wireColor = lerp(_WireframeColor, float4(0,0,0,0), alpha);
                return wireColor;
            }
            ENDCG
        }
    }
}