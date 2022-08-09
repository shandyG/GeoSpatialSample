using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[Serializable]
public class First_Result
{
    public Json_File result;
}


[Serializable]
public class Json_File
{
    public string name;
    public ReviewsInfo[] reviews;
}

[Serializable]
public class ReviewsInfo
{
    public string author_name;
    public string author_url;
    public string profile_photo_url;
    public int rating;
    public string relative_time_description;
    public string text;
    public int time;
}


public class GetWebText : MonoBehaviour
{
    private string placeid = "ChIJszkk5bhhVjUR-V897bo3k0M";
    private string region = "jp";
    private string language = "ja";
    private string key = "";
    private string url = "https://maps.googleapis.com/maps/api/place/details/json?";

    public GameObject pref;


    void Start()
    {
        url += "place_id=" + placeid;
        url += "&region=" + region;
        url += "&language=" + language;
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
            // 結果をテキストで表示
            string inputString = www.downloadHandler.text;
            Debug.Log(inputString);
            //JsonUtiliyを使用して、Jsonデータを処理
            First_Result first_Result = JsonUtility.FromJson<First_Result>(inputString);

            //reviesの数分のPrefabを生成する
            for(int i = 0; i < first_Result.result.reviews.Length - 1 ; i++)

            {
                WWW www2 = new WWW(first_Result.result.reviews[i].profile_photo_url);
                yield return www2;

                //GameObject obj = (GameObject)Instantiate(pref);
                GameObject prefObj = (GameObject)Instantiate(pref);
                GameObject obj = prefObj.transform.Find("Review_Panel").gameObject;

                obj.transform.Find("ReviewerPic").gameObject.GetComponent<RawImage>().texture = www2.texture;
                obj.transform.Find("Place").gameObject.GetComponent<Text>().text = first_Result.result.name;
                obj.transform.Find("ReviewerName").gameObject.GetComponent<Text>().text = first_Result.result.reviews[i].author_name;
                obj.transform.Find("Time").gameObject.GetComponent<Text>().text = first_Result.result.reviews[i].relative_time_description;
                obj.transform.Find("Review").gameObject.GetComponent<Text>().text = first_Result.result.reviews[i].text;
            }


        }
    }
}

/*
 {
   "html_attributions" : [],
   "result" : {
      "address_components" : [
         {
            "long_name" : "９",
            "short_name" : "９",
            "types" : [ "premise" ]
         },
         {
            "long_name" : "大山",
            "short_name" : "大山",
            "types" : [ "sublocality_level_2", "sublocality", "political" ]
         },
         {
            "long_name" : "大山町",
            "short_name" : "大山町",
            "types" : [ "locality", "political" ]
         },
         {
            "long_name" : "西伯郡",
            "short_name" : "西伯郡",
            "types" : [ "administrative_area_level_2", "political" ]
         },
         {
            "long_name" : "鳥取県",
            "short_name" : "鳥取県",
            "types" : [ "administrative_area_level_1", "political" ]
         },
         {
            "long_name" : "日本",
            "short_name" : "JP",
            "types" : [ "country", "political" ]
         },
         {
            "long_name" : "689-3318",
            "short_name" : "689-3318",
            "types" : [ "postal_code" ]
         }
      ],
      "adr_address" : "\u003cspan class=\"country-name\"\u003e日本\u003c/span\u003e、\u003cspan class=\"postal-code\"\u003e〒689-3318\u003c/span\u003e \u003cspan class=\"region\"\u003e鳥取県\u003c/span\u003e\u003cspan class=\"street-address\"\u003e西伯郡大山町大山９\u003c/span\u003e",
      "business_status" : "OPERATIONAL",
      "formatted_address" : "〒689-3318 鳥取県西伯郡大山町大山９",
      "formatted_phone_number" : "0859-52-2158",
      "geometry" : {
         "location" : {
            "lat" : 35.39102309999999,
            "lng" : 133.5347519
         },
         "viewport" : {
            "northeast" : {
               "lat" : 35.39271043029149,
               "lng" : 133.5355777
            },
            "southwest" : {
               "lat" : 35.39001246970849,
               "lng" : 133.5322745
            }
         }
      },
      "icon" : "https://maps.gstatic.com/mapfiles/place_api/icons/v1/png_71/worship_dharma-71.png",
      "icon_background_color" : "#7B9EB0",
      "icon_mask_base_uri" : "https://maps.gstatic.com/mapfiles/place_api/icons/v2/generic_pinlet",
      "international_phone_number" : "+81 859-52-2158",
      "name" : "大山寺",
      "photos" : [
         {
            "height" : 2268,
            "html_attributions" : [
               "\u003ca href=\"https://maps.google.com/maps/contrib/101934584619784485432\"\u003eYasuhiko Kurata\u003c/a\u003e"
            ],
            "photo_reference" : "AeJbb3cgMC8IY-OzO6lFdydoJ3S0Sdig-nP0zUbUZV769N-2fII7zVvEKC9JTKmnGUdyYKsqFjAGZcCQ-uzVFgacX1HEhEtGiHc3uhQry2H3la8WsGxK6gDLqE2KQpOqVWJnzGJgJDLTeFw2LQuwdBiKwcaMbkOGpOtaclDihgO6iG46PH8",
            "width" : 4032
         },
         {
            "height" : 1152,
            "html_attributions" : [
               "\u003ca href=\"https://maps.google.com/maps/contrib/115440742987449895462\"\u003eO. K\u003c/a\u003e"
            ],
            "photo_reference" : "AeJbb3f0880rLf3cZOENZpcIEFc2IrVxHJ8B7Rlr6zKN9M7a7jpvUpHMjP6Nq49hCNcAZYOHebQMwdGQ_s7_OIuW5TrwOY5pyv20z8E7lMzl2v6c7G22GMcISdGGlNzisNg0pvW42i2xRz3lhH-iLiPsu-I7P91gqQEP6g4GUz35aEWOnM6M",
            "width" : 2048
         },
         {
            "height" : 1071,
            "html_attributions" : [
               "\u003ca href=\"https://maps.google.com/maps/contrib/113094381694327840074\"\u003e姫路のシロ\u003c/a\u003e"
            ],
            "photo_reference" : "AeJbb3cOsxghnv-o6mhZoC6QKX5SqWniKbgnWHj4eqskTu_lxw10VhM_g-CfzaxFXp_nE3oMcauYsMVSsiiAxMN5GMPuzvUvfLV_2x9Q4oGtLtWSIrNLlu3K_oEa_FG_Km93zxJ6A9cjsc2--DhIV6jTNLcDDrok2L_yQpFgrYTFR0nijuHQ",
            "width" : 1600
         },
         {
            "height" : 3024,
            "html_attributions" : [
               "\u003ca href=\"https://maps.google.com/maps/contrib/115418247021271775549\"\u003eセノウノリユキ\u003c/a\u003e"
            ],
            "photo_reference" : "AeJbb3f-l6mQ86ZNRU7vsyL-yxcZV1qq-5O4h2ii3QXnM6_KOolidjYhAwJJ7e8nwUYimD0Gz9H8Fr8au7oF4pfIG8e6Nu6oxMnSwd9R4y5xvA_yb0xuQfkqSfC2DT8c3tzzuva9UxHXlHGIrM00k7HfknDsHLjQtVPdqL5VpGNC267wZ5eQ",
            "width" : 4032
         },
         {
            "height" : 855,
            "html_attributions" : [
               "\u003ca href=\"https://maps.google.com/maps/contrib/103046860809443797284\"\u003e小杉T\u003c/a\u003e"
            ],
            "photo_reference" : "AeJbb3eZBbZY4Ch9IG8g8hF1dSm1zFfdP-T0iobQah-x8NdsJp8Q_pBUH-B4YTKb95jubhk3kFpImQgl1Qo_onXJyNr0WX8rOvJqFL8nr3L83p55DHLTn02VhBxKJoLHXwtr8hdpsBLs96ynE6r7cAlOFZS-nd_nSRH0AAK5rFjBM0zcgDv-",
            "width" : 1280
         },
         {
            "height" : 3024,
            "html_attributions" : [
               "\u003ca href=\"https://maps.google.com/maps/contrib/112480772762690769613\"\u003eTakami Kakuta\u003c/a\u003e"
            ],
            "photo_reference" : "AeJbb3ea_j4zSCas3TjgdtHKnQchnSgr5nRplXPPUb7s9jPG40RJKb0TAYjCTNDt1axfUNVeduJikeHha36J7vp0nHT3kAQC4rhhLnWsyKelrxsj1hLV_uA6udNv6RWrU2PIoPkuyctMRYG5nU1kBpZxI52YnNfX0wmf85fQY5G9Ex7tSmOZ",
            "width" : 4032
         },
         {
            "height" : 3968,
            "html_attributions" : [
               "\u003ca href=\"https://maps.google.com/maps/contrib/116965330687466120503\"\u003e板倉昭夫\u003c/a\u003e"
            ],
            "photo_reference" : "AeJbb3fJtH5W__MBLmT7ZWYn72C25WMdbA-KFMDm_udVfcVdKBod1Z1bfkRdl7EhMlj-SMdkzte3nR5brPg3Jv8NAUxsu_cxLlaSk6AF0mO8kNAtrayJexrEKljhQhYAnF4I6NHdzAt-OCmft6qnrfgopet3mxsoAck6idlqnXndWthBbtCB",
            "width" : 2976
         },
         {
            "height" : 3968,
            "html_attributions" : [
               "\u003ca href=\"https://maps.google.com/maps/contrib/116965330687466120503\"\u003e板倉昭夫\u003c/a\u003e"
            ],
            "photo_reference" : "AeJbb3cRpYdXcLW345JWfrOlDYMgo3YzcHZ-1sT6r0C_CUWSikr5A6iDW28ktg-FCa_y34yLMmCKbk2Nf2K7IIrkWHeNTkeloUUaEYgbmSQfXjDXhnAwrYyNeo8ZzCE2vwwqE_IG-AhZfXAXjcHX8-3zTtQoEg_FgfjcanlPU-4ohZQFWzkd",
            "width" : 2976
         },
         {
            "height" : 3024,
            "html_attributions" : [
               "\u003ca href=\"https://maps.google.com/maps/contrib/117622340239179593966\"\u003e七面鳥放浪記\u003c/a\u003e"
            ],
            "photo_reference" : "AeJbb3e_ISLBk3kygck21NYAQfDelBQS-8hPGHNqJdWxYDfGLOs8tDlFgQPqe_V22BjEl3DcJaeUiqeLVQJP26Q1lzPSj0QEdprn9xGBURTprn-FrMV3rrxVEvzq4zRYx4KRRpT8n30jRmhDXNU_LsTWWjkUzGG4XYOMkNAQfxqPEoaaHmes",
            "width" : 4032
         },
         {
            "height" : 3072,
            "html_attributions" : [
               "\u003ca href=\"https://maps.google.com/maps/contrib/107364635517483128824\"\u003e桑原亨\u003c/a\u003e"
            ],
            "photo_reference" : "AeJbb3fZ0JypUSZkVyaQoh7K_eVagZjNzR2OnRXKEdfSV9sqE41nKXGzUz4NEMBQlIXw01HlF1liDjrHNqofUbBydohUpOxhNje_npnwOIleAwycz5aF1tR7akhP-FjbiAyRH2jurcXZ-g84MQOQqew5_iNkd9uQ4ZlhwF84WOHH0VnAvKaF",
            "width" : 4080
         }
      ],
      "place_id" : "ChIJszkk5bhhVjUR-V897bo3k0M",
      "plus_code" : {
         "compound_code" : "9GRM+CW 鳥取県大山町",
         "global_code" : "8Q7M9GRM+CW"
      },
      "rating" : 4.1,
      "reference" : "ChIJszkk5bhhVjUR-V897bo3k0M",
      "reviews" : [
         {
            "author_name" : "Takami Kakuta",
            "author_url" : "https://www.google.com/maps/contrib/112480772762690769613/reviews",
            "language" : "ja",
            "profile_photo_url" : "https://lh3.googleusercontent.com/a-/AFdZucrU4rqfGkhZV7X_4Sn960vqCj3bbFiGqpjMRH8z=s128-c0x00000000-cc-rp-mo-ba7",
            "rating" : 4,
            "relative_time_description" : "1 か月前",
            "text" : "2022年７月初め。神戸から車を飛ばして大山に向かいました。ひとつ目の目的地は木谷沢渓谷。そこからこちらへ。緩やかな上り勾配。階(キザハシ)を登り立看板。もうひとつ奥の階も上がって。奈良時代の開山。順を考えずに下山観音堂からお参りし、護摩堂の不動明王、大山寺本堂の地蔵菩薩とお参りさせていただきました。大山の頂きが垣間見える。",
            "time" : 1656830316
         },
         {
            "author_name" : "小笠原奏",
            "author_url" : "https://www.google.com/maps/contrib/118259533302244641576/reviews",
            "language" : "ja",
            "profile_photo_url" : "https://lh3.googleusercontent.com/a-/AFdZucqOsVNZ4A-LxxiIHEHolFrGNhzMU0LG4Wx92NJOmQ=s128-c0x00000000-cc-rp-mo",
            "rating" : 5,
            "relative_time_description" : "9 か月前",
            "text" : "自然豊か。景色も綺麗。\n登山や散策　冬のスキースノボシーズンには最適。",
            "time" : 1635327229
         },
         {
            "author_name" : "滝口裕美",
            "author_url" : "https://www.google.com/maps/contrib/108206421798543114700/reviews",
            "language" : "ja",
            "profile_photo_url" : "https://lh3.googleusercontent.com/a-/AFdZucqzxOvzdfjV6s2ddsqdNJLqYLY0AEhuIyndc0_c1w=s128-c0x00000000-cc-rp-mo-ba5",
            "rating" : 3,
            "relative_time_description" : "1 か月前",
            "text" : "大神山神社とセットで行かれると良いを思います。駐車場からはそんなに離れてないです。一人、￥300-です。",
            "time" : 1656214018
         },
         {
            "author_name" : "丸山富也",
            "author_url" : "https://www.google.com/maps/contrib/107946784664677445233/reviews",
            "language" : "ja",
            "profile_photo_url" : "https://lh3.googleusercontent.com/a/AItbvmm7u3ouX-BMO_2c-E3UNTCm-up1UFt9XaQxeivI=s128-c0x00000000-cc-rp-mo",
            "rating" : 5,
            "relative_time_description" : "1 週間前",
            "text" : "石段がしんどかったです。\nとても静かで厳かな空気でした。\n本殿左側から大神山神社に行く事が出来ます。",
            "time" : 1658813154
         },
         {
            "author_name" : "Ta Sa",
            "author_url" : "https://www.google.com/maps/contrib/110357389537362454522/reviews",
            "language" : "ja",
            "profile_photo_url" : "https://lh3.googleusercontent.com/a-/AFdZucqAha4OmP5VT61icKDAqBvle1ZTO7-b9D3AZ1nn1A=s128-c0x00000000-cc-rp-mo-ba6",
            "rating" : 5,
            "relative_time_description" : "3 か月前",
            "text" : "大山寺沿革\n\n●開山\n奈良時代養老二年（七一八）出雲の国玉造りの人で依道と云う方によって山が開かれました。\n「大山寺縁起」によると依道がある日金色の狼を追って大山に入り一矢にして射殺さんとすれば、矢の前方に地蔵菩薩が現れ信心の心がにわかに起こり弓矢を捨てました。\n狼はいつの間にか老尼と化し依道に話しかけました。\nこの出来事により依道はすみやかに出家、仏道の修行をしこの山に地蔵権現を祀りその名を金蓮と改めたと記されています。\nまた「選集抄」にもほぼ同じ説話がのっています。\n●山号\n「大山寺縁起」によると、天空はるかかなたの兜率天の角が欠けて大きな盤石が地上に落ちて来ました。\n盤石は三つに割れてその一つは熊野山になり、二つは金峰山になり、三つはこの大山になりました。\nこうしたことからこの山を角磐山（かくばんざん）と名付けられました。\n大山寺は山岳信仰の対象となる霊山大山に早くから山岳修行僧が入り「修験の山」として全国に知られました。\n●権現号\n平安時代、村上天皇より大山権現（地蔵権現）を大智明菩薩とするみことのりが下され、御本尊を本殿権現社（現在の「大神山神社奥宮」）にまつり大智明権現というようになりました。\n両部習合、すなわち神と仏とを一緒に御祀りする習わしで明治初めまで続きましたが当時の神仏分離の政策により別けられました。\n●慈覚大師\n一一〇〇年程前、貞観年間天台宗の高僧慈覚大師が当山に顕密両教と共に「引声阿弥陀経」の秘曲を伝えられました。\n当山の行者これに帰依し、修験道から天台宗に列し今日に至っています。\n●阿弥陀堂\n「引声の阿弥陀経」の修業の道場として常行三昧堂という二十四間四面の大きな御堂が建てられたのですが、享録二年大洪水の際流失し、天文二十一年（一五五二）その残木によって五間四面の現在の堂が再建されています。\n中に安置されている丈六の木造阿弥陀如来は天承元年（一一三一）大仏師良圓の作で両脇侍・御堂共に重要文化財に指定されています。\n●承安の大火\n承安元年（一一七一）不幸にも大火災を起こし、本尊様を始め諸堂も焼失してしまいました。その頃、近くの長者原に一大勢力を持っていた「紀成盛」によって御堂が再建され金銅の地蔵尊及び鉄製の厨子（重文）が奉納され再興されたのです。\n●僧兵\n戦国時代の末世になり世が乱れ至る所に騒動が起こり、寺院も兵力を用いなければ保護する事が出来なくなりました。\n大山寺も僧兵を蓄え強力な勢力を誇っていました。\n元弘三年、当山の別当職にあった信濃坊源盛は兄名和長年公が後醍醐天皇を奉じて船上山に立てこもった際、兄の義挙を助け当山の僧兵七百余騎をしたがえて船上山に馳せ参じ王事に勤めたのです。\n●豪円僧正\n慶長年間豪円僧正は当寺の座主となり、内に山の法規を定め四十二の山内支院をもって寺運の挽回を計り、幕府に請って三千石の地領を得、次いで寛永七年からは代々宮様が座主につかれるようになり、法憧再び輝くに至りました。\n●明治時代\n明治初年、神と仏とを別々に祀れという所謂神仏分離の政令が出され、当時の座主北白川能久親王もどうする事もできず実に開山以来、一,二〇〇年の間、御本尊を御祀りしていた本殿を、明治八年神社に引き渡し大日堂にうつし祀らねばならなくなりました。\n寺号も廃絶し、大山寺一山は急激に頽廃するに至ったのです。\n●昭和の火災\n寺号復興もつかの間、昭和三年再び火災を起こし仮本堂は焼失し、以来二十年の歳月を経て昭和二十六年にようやく現在の本堂の落慶法要をみる事になりました。しかし、現在も尚、山内寺院十ヶ院、重要文化財阿弥陀堂及び弥陀三尊を初め宝物類も数多く残され、実に山陰の名刹として、天台でいう所謂鎮護国家の霊場として更に中国地方一円の人々から御先祖様に会える寺として、又、人間再生の寺として崇敬を集めているのです。\n大山寺ホームページより",
            "time" : 1650106186
         }
      ],
      "types" : [
         "tourist_attraction",
         "place_of_worship",
         "point_of_interest",
         "establishment"
      ],
      "url" : "https://maps.google.com/?cid=4869296898101305337",
      "user_ratings_total" : 962,
      "utc_offset" : 540,
      "vicinity" : "大山町大山９",
      "website" : "http://daisenji.jp/"
   },
   "status" : "OK"
}

UnityEngine.Debug:Log (object)
GetWebText/<GetText>d__6:MoveNext () (at Assets/GetWebText.cs:41)
UnityEngine.SetupCoroutine:InvokeMoveNext (System.Collections.IEnumerator,intptr)

 */