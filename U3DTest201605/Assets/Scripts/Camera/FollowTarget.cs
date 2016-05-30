using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    // 观测对象
    private GameObject target;
 
    //距离
    public float distanceX = 0f;
    public float distanceY = 0f;
    public float distanceZ = -5f;
    public float maxDistance = -50f;
    public float minDistance = -5f;
 
    //角度
    public float angleX = 30f;
    public float angleY = 0f;
    public float angleZ = 0f;
    public float anglespeed = 5f;
    public float scrollSpeed = 250f;
 
 
 
    void Start()
    {
        target = GameObject.Find("Cube");
    }
 
    void Update()
    {
        Mouse();
 
        UpdateCarema();
    }
 
    void OnGUI()
    {
        string text;
        float y = 0;
        float dis = 20;
        GUI.Label(new Rect(0, 0, 90, 30), "distanceX : ");
        distanceX = GUI.HorizontalSlider(new Rect(90, 0, 100, 10), distanceX, -30.0F, 30.0F);
        text = GUI.TextField(new Rect(190, 0, 50, 20), distanceX.ToString(), 6);
        distanceX = float.Parse(text == "" ? "0" : text);
 
        y += dis;
        GUI.Label(new Rect(0, y, 90, 30), "distanceY : ");
        distanceY = GUI.HorizontalSlider(new Rect(90, y, 100, 10), distanceY, -30.0F, 30.0F);
        text = GUI.TextField(new Rect(190, y, 50, 20), distanceY.ToString(), 6);
        distanceY = float.Parse(text == "" ? "0" : text);
 
        y += dis;
        GUI.Label(new Rect(0, y, 90, 30), "distanceZ : ");
        distanceZ = GUI.HorizontalSlider(new Rect(90, y, 100, 10), distanceZ, maxDistance, minDistance);
        text = GUI.TextField(new Rect(190, y, 50, 20), distanceZ.ToString(), 6);
        distanceZ = float.Parse(text == "" ? "0" : text);
 
        y += dis;
        GUI.Label(new Rect(0, y, 90, 30), "maxDistance : ");
        maxDistance = GUI.HorizontalSlider(new Rect(90, y, 100, 10), maxDistance, -100, 100.0F);
        text = GUI.TextField(new Rect(190, y, 50, 20), maxDistance.ToString(), 6);
        maxDistance = float.Parse(text == "" ? "0" : text);
 
        y += dis;
        GUI.Label(new Rect(0, y, 90, 30), "minDistance : ");
        minDistance = GUI.HorizontalSlider(new Rect(90, y, 100, 10), minDistance, -100, 100.0F);
        text = GUI.TextField(new Rect(190, y, 50, 20), minDistance.ToString(), 6);
        minDistance = float.Parse(text == "" ? "0" : text);
 
        y += dis;
        GUI.Label(new Rect(0, y, 90, 30), "angleX : ");
        angleX = GUI.HorizontalSlider(new Rect(90, y, 100, 10), angleX, -360.0F, 360.0F);
        text = GUI.TextField(new Rect(190, y, 50, 20), angleX.ToString(), 6);
        angleX = float.Parse(text == "" ? "0" : text);
 
        y += dis;
        GUI.Label(new Rect(0, y, 90, 30), "angleY : ");
        angleY = GUI.HorizontalSlider(new Rect(90, y, 100, 10), angleY, -360.0F, 360.0F);
        text = GUI.TextField(new Rect(190, y, 50, 20), angleY.ToString(), 6);
        angleY = float.Parse(text == "" ? "0" : text);
 
        y += dis;
        GUI.Label(new Rect(0, y, 90, 30), "angleZ : ");
        angleZ = GUI.HorizontalSlider(new Rect(90, y, 100, 10), angleZ, -360.0F, 360.0F);
        text = GUI.TextField(new Rect(190, y, 50, 20), angleZ.ToString(), 6);
        angleZ = float.Parse(text == "" ? "0" : text);
 
        y += dis;
        GUI.Label(new Rect(0, y, 90, 30), "speed : ");
        anglespeed = GUI.HorizontalSlider(new Rect(90, y, 100, 10), anglespeed, 100.0F, 0.0F);
        text = GUI.TextField(new Rect(190, y, 50, 20), anglespeed.ToString(), 6);
        anglespeed = float.Parse(text == "" ? "0" : text);
 
        y += dis;
        GUI.Label(new Rect(0, y, 90, 30), "scrollSpeed : ");
        scrollSpeed = GUI.HorizontalSlider(new Rect(90, y, 100, 10), scrollSpeed, 500.0F, 0.0F);
        text = GUI.TextField(new Rect(190, y, 50, 20), scrollSpeed.ToString(), 6);
        scrollSpeed = float.Parse(text == "" ? "0" : text);
 
    }
 
    private void Mouse()
    {
        if (Input.GetMouseButton(1))
        {
            angleY += Input.GetAxis("Mouse X") * anglespeed;
            angleX -= Input.GetAxis("Mouse Y") * anglespeed;
        }
 
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            //根据鼠标滚轮都值计算出这一帧应该移动都距离。
            distanceZ += Mathf.Lerp(0, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, Time.deltaTime);
            //判断是否超过最大范围
            distanceZ = Mathf.Clamp(distanceZ, maxDistance, minDistance);
        }
    }
 
 
    private void UpdateCarema()
    {
        //通过围绕x、y、z轴都角度创建一个四元数
        Quaternion rotation = Quaternion.Euler(angleX, angleY, angleZ);
        //创建一个位移向量。
        Vector3 Pos = new Vector3(distanceX, distanceY, distanceZ);
        //将上面都向量选择对应四元数所表示都角度。
        Vector3 move = rotation * Pos;
        //从目标点进行move向量的移动。得到一个新都位置。
        Vector3 pos = move + target.transform.position;
 
        //赋值给摄像机新的位置
        transform.position = pos;
        //赋值给摄像机新都旋转
        transform.rotation = rotation;
 
    }
}
