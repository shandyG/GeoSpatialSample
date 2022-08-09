using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[Serializable]
public class SpotResult{
    public GeoFile[] results;
}

[Serializable]
public class GeoFile
{
    public LocationInfo geometry;
    public string name;
    public string place_id;
}

[Serializable]
public class LocationInfo{
    public LatLngInfo location;
}

[Serializable]
public class LatLngInfo
{
    public string lat;
    public string lng;
}



public class GetClosePlace : MonoBehaviour
{
    private string keyword = "";
    private string language = "ja";
    private string location = "35.450375035717954" + "%2C" + "139.56406400174714";
    private int radius = 1000;
    private string key = "";
    private string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";

    // Start is called before the first frame update
    void Start()
    {
        url += "keyword=" + keyword;
        url += "&language=" + language;
        url += "&location=" + location;
        url += "&radius=" + radius;
        url += "&key=" + key;


        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string inputString = www.downloadHandler.text;
            Debug.Log(inputString);
            SpotResult spot_Result = JsonUtility.FromJson<SpotResult>(inputString);
            Debug.Log(spot_Result.results[0].name);
            Debug.Log(spot_Result.results[1].name);
            Debug.Log(spot_Result.results[1].geometry.location.lat);
            Debug.Log(spot_Result.results[2].geometry.location.lat);
            Debug.Log(spot_Result.results.Length　-1);
        }

    }

            // Update is called once per frame
            void Update()
    {
        
    }
}


/*
 {
   "html_attributions" : [],
   "next_page_token" : "AeJbb3dKYml3oybCEUlU-N2Xe9odLYC_NxOg7CYf6OrSQdg2vwoTzlQ-PKNaEGvIxpx6B3w9odi-49Sdy6NxsILKOzEJefwzd53KhQZFjZr3J03tukyxsWD2_4gt5S8Mn3CAyRx2_g3rYijQMzVANglJX5f2vjE89GPt0umJ4lUbfHnhF9mkQQtcj4AbloO58qvLBmq1nkiGgX0q7-lhyoEp7jG0kB2Dr_k1ZMkzs0h0f6-xX58HtfM4oCxMGHAmEcUSo98sTCc7IojWJXwMYwwVZhzfQ-2SNjel3udRF602TZBUtuLB2ywejyvkLOPyPlrVSG-jZ7Ub1h8nFxRmof4e-EkPD3BXttzUx--NsGDLmewhkTBNUweqTNOnKYUmaO2NBlWfqpMGjfYyVGK1lR-dsBQ2ckxTPg92-xRdB6th",
   "results" : [
      {
         "geometry" : {
            "location" : {
               "lat" : 35.4436739,
               "lng" : 139.6379639
            },
            "viewport" : {
               "northeast" : {
                  "lat" : 35.59283835256976,
                  "lng" : 139.7253575326474
               },
               "southwest" : {
                  "lat" : 35.31261128095807,
                  "lng" : 139.4647645591694
               }
            }
         },
         "icon" : "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/geocode-71.png",
         "icon_background_color" : "#7B9EB0",
         "icon_mask_base_uri" : "https://maps.gstatic.com/mapfiles/place_api/icons/v2/generic_pinlet",
         "name" : "横浜市",
         "photos" : [
            {
               "height" : 3024,
               "html_attributions" : [
                  "\u003ca href=\"https://maps.google.com/maps/contrib/100458463861154420797\"\u003eBON Bon\u003c/a\u003e"
               ],
               "photo_reference" : "AeJbb3eJZ8C3fBBE1gklx1u9FupU1YloOcxXJsIafq5r7dl-siRDpPvq6AbNCMm99rFHUkEuzFj3Uy888wVCkXqg72_6WgK0DkfVt6s0hfpI2jOJKLujm77A1NUnxefBXg0DHojwn_PZ_ibM2y8YounJ887zpaikeIV-fRbKJ5nnl9YreqKx",
               "width" : 4032
            }
         ],
         "place_id" : "ChIJCWW2u-xbGGARAFQoYPaDlgY",
         "reference" : "ChIJCWW2u-xbGGARAFQoYPaDlgY",
         "scope" : "GOOGLE",
         "types" : [ "locality", "political" ],
         "vicinity" : "横浜市"
      },
      {
         "business_status" : "OPERATIONAL",
         "geometry" : {
            "location" : {
               "lat" : 35.4542326,
               "lng" : 139.5677808
            },
            "viewport" : {
               "northeast" : {
                  "lat" : 35.45556998029149,
                  "lng" : 139.5690724802915
               },
               "southwest" : {
                  "lat" : 35.45287201970849,
                  "lng" : 139.5663745197085
               }
            }
         },
         "icon" : "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/generic_business-71.png",
         "icon_background_color" : "#7B9EB0",
         "icon_mask_base_uri" : "https://maps.gstatic.com/mapfiles/place_api/icons/v2/generic_pinlet",
         "name" : "ハンズゴルフクラブ",
         "opening_hours" : {
            "open_now" : false
         },
         "photos" : [
            {
               "height" : 3328,
               "html_attributions" : [
                  "\u003ca href=\"https://maps.google.com/maps/contrib/116786464319093532373\"\u003eハンズゴルフクラブ\u003c/a\u003e"
               ],
               "photo_reference" : "AeJbb3cYeGq6db29nyByNK58qzZTnIAMYE9GAwhg-DAN6WdERwPIEPbgP2Uuj8tcbjINc2mDdiCR2kh3Xagnp8IKgFu-a-kOjo2diIyFByDEHXB_YUUIldXpcezyd4N1tLfuQjKCrZp0naWdzafJnm48EM2IhCpDnUIpIR1LCDgqoVg-x1N9",
               "width" : 4992
            }
         ],
         "place_id" : "ChIJA3BdoyxaGGAR9ZONIfGU9O0",
         "plus_code" : {
            "compound_code" : "FH39+M4 日本、神奈川県横浜市",
            "global_code" : "8Q7XFH39+M4"
         },
         "rating" : 4,
         "reference" : "ChIJA3BdoyxaGGAR9ZONIfGU9O0",
         "scope" : "GOOGLE",
         "types" : [ "point_of_interest", "establishment" ],
         "user_ratings_total" : 489,
         "vicinity" : "横浜市保土ケ谷区仏向町１５５８"
      },
      {
         "business_status" : "OPERATIONAL",
         "geometry" : {
            "location" : {
               "lat" : 35.44414,
               "lng" : 139.561599
            },
            "viewport" : {
               "northeast" : {
                  "lat" : 35.4454448802915,
                  "lng" : 139.5629785802915
               },
               "southwest" : {
                  "lat" : 35.4427469197085,
                  "lng" : 139.5602806197085
               }
            }
         },
         "icon" : "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/restaurant-71.png",
         "icon_background_color" : "#FF9E67",
         "icon_mask_base_uri" : "https://maps.gstatic.com/mapfiles/place_api/icons/v2/restaurant_pinlet",
         "name" : "Bistro Vin Vino",
         "opening_hours" : {
            "open_now" : false
         },
         "photos" : [
            {
               "height" : 1365,
               "html_attributions" : [
                  "\u003ca href=\"https://maps.google.com/maps/contrib/107446846951494287374\"\u003eBistro Vin Vino\u003c/a\u003e"
               ],
               "photo_reference" : "AeJbb3frkoZ_3BFYlnN8iaYXovv2lWE6Yp3NbW6WgVX9Ajy9dvFDYqhwjk7Hxv3vOXbI02cGJd0L_YV2BMfC5oPVrGGW6i-PM_hsGMhjNKampC-FtXgX8n6tXMn_c7xLnaMYsEGi6yOQRcyOx914NvWoZsN2s1aiej-ZRLfk4U2DO7Ounm3s",
               "width" : 2048
            }
         ],
         "place_id" : "ChIJY9lUGDFaGGARM14qXmKkhpM",
         "plus_code" : {
            "compound_code" : "CHV6+MJ 日本、神奈川県横浜市",
            "global_code" : "8Q7XCHV6+MJ"
         },
         "price_level" : 2,
         "rating" : 4.1,
         "reference" : "ChIJY9lUGDFaGGARM14qXmKkhpM",
         "scope" : "GOOGLE",
         "types" : [ "restaurant", "food", "point_of_interest", "establishment" ],
         "user_ratings_total" : 63,
         "vicinity" : "横浜市保土ケ谷区今井町１３２２−４"
      },
      {
         "business_status" : "OPERATIONAL",
         "geometry" : {
            "location" : {
               "lat" : 35.445685,
               "lng" : 139.562855
            },
            "viewport" : {
               "northeast" : {
                  "lat" : 35.4470008802915,
                  "lng" : 139.5642461302915
               },
               "southwest" : {
                  "lat" : 35.4443029197085,
                  "lng" : 139.5615481697085
               }
            }
         },
         "icon" : "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/restaurant-71.png",
         "icon_background_color" : "#FF9E67",
         "icon_mask_base_uri" : "https://maps.gstatic.com/mapfiles/place_api/icons/v2/restaurant_pinlet",
         "name" : "増田屋",
         "opening_hours" : {
            "open_now" : false
         },
         "photos" : [
            {
               "height" : 3096,
               "html_attributions" : [
                  "\u003ca href=\"https://maps.google.com/maps/contrib/116833789438118302908\"\u003eぷにぷにIII世\u003c/a\u003e"
               ],
               "photo_reference" : "AeJbb3eWNfAeTMHq-lseUvhZBwJq-0Jhft3uKBIZUTZzwga-NwA67tWlyR02JP1Bqf7y7tEHp2VECyde6v403EWgMxfxroaYHm6urpHLblIob255gNp_MTGAeUsu9NIXeC76rVpX8-zKMTk1QYi_0mGgFW1p8ckYwt3FZysVkw66hYzv84jd",
               "width" : 5504
            }
         ],
         "place_id" : "ChIJa6MddzFaGGARJ4fK0mC6Zik",
         "plus_code" : {
            "compound_code" : "CHW7+74 日本、神奈川県横浜市",
            "global_code" : "8Q7XCHW7+74"
         },
         "price_level" : 2,
         "rating" : 4,
         "reference" : "ChIJa6MddzFaGGARJ4fK0mC6Zik",
         "scope" : "GOOGLE",
         "types" : [ "restaurant", "food", "point_of_interest", "establishment" ],
         "user_ratings_total" : 80,
         "vicinity" : "横浜市保土ケ谷区今井町６４−１"
      },
      {
         "business_status" : "OPERATIONAL",
         "geometry" : {
            "location" : {
               "lat" : 35.4572581,
               "lng" : 139.558977
            },
            "viewport" : {
               "northeast" : {
                  "lat" : 35.4586642802915,
                  "lng" : 139.5602950302915
               },
               "southwest" : {
                  "lat" : 35.4559663197085,
                  "lng" : 139.5575970697085
               }
            }
         },
         "icon" : "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/school-71.png",
         "icon_background_color" : "#7B9EB0",
         "icon_mask_base_uri" : "https://maps.gstatic.com/mapfiles/place_api/icons/v2/school_pinlet",
         "name" : "専門学校日産横浜自動車大学校",
         "photos" : [
            {
               "height" : 3024,
               "html_attributions" : [
                  "\u003ca href=\"https://maps.google.com/maps/contrib/111684829597725207142\"\u003eK. Tak.\u003c/a\u003e"
               ],
               "photo_reference" : "AeJbb3c3obmD4dkJEh7pteCgqxhuvHDEsiD8ec5WEgZaTqf_y1gpMk-lKM06qyzFXoMwdSd3rm2_LFQhun8JuefHML6tCilsUujEPGPVafBOiqH6k93_YaneaROElu0rR_kXfO-FfsImseWzwMWoOC6wJw_TSXIryboKzhWCChOhRg3K8WJM",
               "width" : 4032
            }
         ],
         "place_id" : "ChIJbcL424dZGGARV7Fq7Np2jvk",
         "plus_code" : {
            "compound_code" : "FH45+WH 日本、神奈川県横浜市",
            "global_code" : "8Q7XFH45+WH"
         },
         "rating" : 3.3,
         "reference" : "ChIJbcL424dZGGARV7Fq7Np2jvk",
         "scope" : "GOOGLE",
         "types" : [ "point_of_interest", "establishment" ],
         "user_ratings_total" : 35,
         "vicinity" : "横浜市旭区市沢町９１０"
      },
      {
         "business_status" : "OPERATIONAL",
         "geometry" : {
            "location" : {
               "lat" : 35.4460094,
               "lng" : 139.5664768
            },
            "viewport" : {
               "northeast" : {
                  "lat" : 35.44731618029149,
                  "lng" : 139.5677279802915
               },
               "southwest" : {
                  "lat" : 35.4446182197085,
                  "lng" : 139.5650300197085
               }
            }
         },
         "icon" : "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/shopping-71.png",
         "icon_background_color" : "#4B96F3",
         "icon_mask_base_uri" : "https://maps.gstatic.com/mapfiles/place_api/icons/v2/shopping_pinlet",
         "name" : "トヨタ モビリティパーツ 神奈川支社 横浜店",
         "opening_hours" : {
            "open_now" : false
         },
         "photos" : [
            {
               "height" : 729,
               "html_attributions" : [
                  "\u003ca href=\"https://maps.google.com/maps/contrib/114483441301722944476\"\u003ezero J\u003c/a\u003e"
               ],
               "photo_reference" : "AeJbb3fmXE-YyVf3YKMxMtQ6FJ0nrPmWgrrAmi16tBV73XagH3VTBNgZioAkMFCEqEVY1Rm7-Xnncf074tu6dr0M100je0ncNMMxuToeSjLKoGpPxprgNKb4exUipj1FGcycxGdjEfB3x-RtYwhlHBuGeAKGo5eSTAhSMgqS-A0iiEdE9vJ1",
               "width" : 1612
            }
         ],
         "place_id" : "ChIJDQzRezNaGGARQhEuzzTazic",
         "plus_code" : {
            "compound_code" : "CHW8+CH 日本、神奈川県横浜市",
            "global_code" : "8Q7XCHW8+CH"
         },
         "rating" : 4,
         "reference" : "ChIJDQzRezNaGGARQhEuzzTazic",
         "scope" : "GOOGLE",
         "types" : [ "car_repair", "point_of_interest", "establishment" ],
         "user_ratings_total" : 106,
         "vicinity" : "横浜市保土ケ谷区法泉３丁目２７−９"
      },
      {
         "business_status" : "OPERATIONAL",
         "geometry" : {
            "location" : {
               "lat" : 35.4456776,
               "lng" : 139.5647432
            },
            "viewport" : {
               "northeast" : {
                  "lat" : 35.44703913029149,
                  "lng" : 139.5660533302915
               },
               "southwest" : {
                  "lat" : 35.44434116970849,
                  "lng" : 139.5633553697085
               }
            }
         },
         "icon" : "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/restaurant-71.png",
         "icon_background_color" : "#FF9E67",
         "icon_mask_base_uri" : "https://maps.gstatic.com/mapfiles/place_api/icons/v2/restaurant_pinlet",
         "name" : "居酒屋 てぃーす。",
         "opening_hours" : {
            "open_now" : false
         },
         "photos" : [
            {
               "height" : 4000,
               "html_attributions" : [
                  "\u003ca href=\"https://maps.google.com/maps/contrib/105642193292026536988\"\u003e卓\u003c/a\u003e"
               ],
               "photo_reference" : "AeJbb3dkNgQIlAf8dObnewUecUlDxW3dG0eytuseTq7sPnuZ-cdiJtKTGg50zNzzzYFoY4MAlKmDNWqZcUR2PlMzv-lTyj4mTAmo0cN3y4Rx206rZfbaoksMTR9FUu9CNyf0eQ0uBoPnj2NDJ81R0TicCVRzbIecyP9sdjULM1hy4RTX4K7g",
               "width" : 6000
            }
         ],
         "place_id" : "ChIJj9ITuDNaGGARR9fFblWhpS0",
         "plus_code" : {
            "compound_code" : "CHW7+7V 日本、神奈川県横浜市",
            "global_code" : "8Q7XCHW7+7V"
         },
         "price_level" : 1,
         "rating" : 4.4,
         "reference" : "ChIJj9ITuDNaGGARR9fFblWhpS0",
         "scope" : "GOOGLE",
         "types" : [ "restaurant", "food", "point_of_interest", "establishment" ],
         "user_ratings_total" : 10,
         "vicinity" : "横浜市保土ケ谷区新桜ケ丘１丁目１−１"
      },
      {
         "business_status" : "OPERATIONAL",
         "geometry" : {
            "location" : {
               "lat" : 35.450601,
               "lng" : 139.56621
            },
            "viewport" : {
               "northeast" : {
                  "lat" : 35.45192883029149,
                  "lng" : 139.5676309302915
               },
               "southwest" : {
                  "lat" : 35.44923086970849,
                  "lng" : 139.5649329697085
               }
            }
         },
         "icon" : "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/generic_business-71.png",
         "icon_background_color" : "#7B9EB0",
         "icon_mask_base_uri" : "https://maps.gstatic.com/mapfiles/place_api/icons/v2/generic_pinlet",
         "name" : "（株）ホーム・イン・ワン",
         "opening_hours" : {
            "open_now" : false
         },
         "place_id" : "ChIJVT5gdS1aGGARp93CtLIVSN4",
         "plus_code" : {
            "compound_code" : "FH28+6F 日本、神奈川県横浜市",
            "global_code" : "8Q7XFH28+6F"
         },
         "rating" : 4.5,
         "reference" : "ChIJVT5gdS1aGGARp93CtLIVSN4",
         "scope" : "GOOGLE",
         "types" : [ "point_of_interest", "establishment" ],
         "user_ratings_total" : 2,
         "vicinity" : "横浜市保土ケ谷区新桜ケ丘１丁目２８−５ ホーム・イン・ワン"
      },
      {
         "business_status" : "OPERATIONAL",
         "geometry" : {
            "location" : {
               "lat" : 35.45583099999999,
               "lng" : 139.563991
            },
            "viewport" : {
               "northeast" : {
                  "lat" : 35.45741613029149,
                  "lng" : 139.5655641802915
               },
               "southwest" : {
                  "lat" : 35.45471816970849,
                  "lng" : 139.5628662197085
               }
            }
         },
         "icon" : "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/hospital-71.png",
         "icon_background_color" : "#F88181",
         "icon_mask_base_uri" : "https://maps.gstatic.com/mapfiles/place_api/icons/v2/hospital-H_pinlet",
         "name" : "横浜療育医療センター",
         "opening_hours" : {
            "open_now" : false
         },
         "photos" : [
            {
               "height" : 2844,
               "html_attributions" : [
                  "\u003ca href=\"https://maps.google.com/maps/contrib/115046127666862475224\"\u003emasa naga\u003c/a\u003e"
               ],
               "photo_reference" : "AeJbb3fRzQAOQxGH63aYcFakdzUy8GGPXS-IHY82kQDODgz2GZVM3weEUg4CJg0epVb4qg4qa5xyXOjIxLiXNo16VMwfCEwXJmkQFfkg6fMGrtzV1hboQrcSZlrS8Ak-zDgZo2xYnauN7b9kumyPViEcv10H63HiiCH_j6mTmLt8MPcr<message truncated>
 */