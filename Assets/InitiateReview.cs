using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class InitiateReview : MonoBehaviour
{

    private string author_name= "丸山富也";
    private string author_url = "https://www.google.com/maps/contrib/110357389537362454522/reviews";
    private string profile_photo_url = "https://lh3.googleusercontent.com/a-/AFdZucqAha4OmP5VT61icKDAqBvle1ZTO7-b9D3AZ1nn1A=s128-c0x00000000-cc-rp-mo-ba6";
    private int rating = 5;
    private string relative_time_description = "3 か月前";
    private string text = "大山寺沿革\n\n●開山\n奈良時代養老二年（七一八）出雲の国玉造りの人で依道と云う方によって山が開かれました。\n「大山寺縁起」によると依道がある日金色の狼を追って大山に入り一矢にして射殺さんとすれば、矢の前方に地蔵菩薩が現れ信心の心がにわかに起こり弓矢を捨てました。\n狼はいつの間にか老尼と化し依道に話しかけました。\nこの出来事により依道はすみやかに出家、仏道の修行をしこの山に地蔵権現を祀りその名を金蓮と改めたと記されています。\nまた「選集抄」にもほぼ同じ説話がのっています。\n●山号\n「大山寺縁起」によると、天空はるかかなたの兜率天の角が欠けて大きな盤石が地上に落ちて来ました。\n盤石は三つに割れてその一つは熊野山になり、二つは金峰山になり、三つはこの大山になりました。\nこうしたことからこの山を角磐山（かくばんざん）と名付けられました。\n大山寺は山岳信仰の対象となる霊山大山に早くから山岳修行僧が入り「修験の山」として全国に知られました。\n●権現号\n平安時代、村上天皇より大山権現（地蔵権現）を大智明菩薩とするみことのりが下され、御本尊を本殿権現社（現在の「大神山神社奥宮」）にまつり大智明権現というようになりました。\n両部習合、すなわち神と仏とを一緒に御祀りする習わしで明治初めまで続きましたが当時の神仏分離の政策により別けられました。\n●慈覚大師\n一一〇〇年程前、貞観年間天台宗の高僧慈覚大師が当山に顕密両教と共に「引声阿弥陀経」の秘曲を伝えられました。\n当山の行者これに帰依し、修験道から天台宗に列し今日に至っています。\n●阿弥陀堂\n「引声の阿弥陀経」の修業の道場として常行三昧堂という二十四間四面の大きな御堂が建てられたのですが、享録二年大洪水の際流失し、天文二十一年（一五五二）その残木によって五間四面の現在の堂が再建されています。\n中に安置されている丈六の木造阿弥陀如来は天承元年（一一三一）大仏師良圓の作で両脇侍・御堂共に重要文化財に指定されています。\n●承安の大火\n承安元年（一一七一）不幸にも大火災を起こし、本尊様を始め諸堂も焼失してしまいました。その頃、近くの長者原に一大勢力を持っていた「紀成盛」によって御堂が再建され金銅の地蔵尊及び鉄製の厨子（重文）が奉納され再興されたのです。\n●僧兵\n戦国時代の末世になり世が乱れ至る所に騒動が起こり、寺院も兵力を用いなければ保護する事が出来なくなりました。\n大山寺も僧兵を蓄え強力な勢力を誇っていました。\n元弘三年、当山の別当職にあった信濃坊源盛は兄名和長年公が後醍醐天皇を奉じて船上山に立てこもった際、兄の義挙を助け当山の僧兵七百余騎をしたがえて船上山に馳せ参じ王事に勤めたのです。\n●豪円僧正\n慶長年間豪円僧正は当寺の座主となり、内に山の法規を定め四十二の山内支院をもって寺運の挽回を計り、幕府に請って三千石の地領を得、次いで寛永七年からは代々宮様が座主につかれるようになり、法憧再び輝くに至りました。\n●明治時代\n明治初年、神と仏とを別々に祀れという所謂神仏分離の政令が出され、当時の座主北白川能久親王もどうする事もできず実に開山以来、一,二〇〇年の間、御本尊を御祀りしていた本殿を、明治八年神社に引き渡し大日堂にうつし祀らねばならなくなりました。\n寺号も廃絶し、大山寺一山は急激に頽廃するに至ったのです。\n●昭和の火災\n寺号復興もつかの間、昭和三年再び火災を起こし仮本堂は焼失し、以来二十年の歳月を経て昭和二十六年にようやく現在の本堂の落慶法要をみる事になりました。しかし、現在も尚、山内寺院十ヶ院、重要文化財阿弥陀堂及び弥陀三尊を初め宝物類も数多く残され、実に山陰の名刹として、天台でいう所謂鎮護国家の霊場として更に中国地方一円の人々から御先祖様に会える寺として、又、人間再生の寺として崇敬を集めているのです。\n大山寺ホームページより";
    private int time;

    public GameObject pref;

    // Start is called before the first frame update
    IEnumerator Start()
    {

        WWW www = new WWW(profile_photo_url);
        yield return www;

        GameObject obj = (GameObject)Instantiate(pref);
        obj.transform.Find("ReviewerPic").gameObject.GetComponent<RawImage>().texture = www.texture;
        obj.transform.Find("ReviewerName").gameObject.GetComponent<Text>().text = author_name;
        obj.transform.Find("Time").gameObject.GetComponent<Text>().text = relative_time_description;
        obj.transform.Find("Review").gameObject.GetComponent<Text>().text = text;

        Debug.Log(rating);

        for (int i = 0; i < rating ; i++)
        {
            Debug.Log("count");
            obj.transform.Find("Rate").gameObject.GetComponent<Text>().text += "★";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
