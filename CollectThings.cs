using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollectThings : MonoBehaviour
{
    public string thingTag = "NPC";

    public int maxThings = 1;
    public float followDamping = .1f;
    public float followDistance= .1f;
    public float maxFollowDistance = .5f;
    public float power = 100;
    public float forceToApply;
    private const float V = 3.5f;
    public bool collectedKey;

    public List<GameObject> collected;
    public List<SpringJoint2D> joints;

    public Rigidbody2D rb2d;

    public bool isThrown;

    private Vector3 gravity = Vector3.down * V;
    void Start()
    {
        // Initialize lists. Makes sure they're not null and empty. 
        collected = new List<GameObject>();
        joints = new List<SpringJoint2D>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W) && collected.Count == maxThings)
        {

            isThrown = true;
            StartCoroutine("BreakTrigger");
        }

        else
        {
            isThrown = false;
        }

        
    }
    private void FixedUpdate()
    {
        rb2d.AddForce(new Vector2(rb2d.velocity.x, forceToApply), ForceMode2D.Impulse);
        rb2d.AddForce(gravity);

        if (Input.GetKey(KeyCode.W) && collected.Count == maxThings)
        {
            forceToApply = 500f;
            isThrown = true;

        }

        if (forceToApply > 0 && isThrown)
        {
            forceToApply = 0;
            isThrown = false;
        }

        if (isThrown)
        {
            RemoveAll();
            StartCoroutine(BreakTrigger());
            collectedKey = false;
        }


        if (followDistance >= maxFollowDistance)
        {
            followDistance = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Is this something we want to collect?
        if (other.gameObject.CompareTag(thingTag))
        {
            // If already at maximum limit, abort.
            if (collected.Count >= maxThings)
                return;
            AddThing(other.gameObject);
            collectedKey = true;
        }

        if (other.CompareTag("Door") && collectedKey == true && isThrown == false)
        {
            // This scene HAS TO BE IN THE BUILD SETTINGS!!!
            SceneManager.LoadScene("scene1");
        }

    }
    public void AddThing(GameObject obj)
    {
        // Add a joint to this object.
        var j = gameObject.AddComponent<SpringJoint2D>();

        // Connect thing to the joint and set joint settings.
        j.autoConfigureConnectedAnchor = true;
        j.dampingRatio = followDamping;
        j.connectedBody = obj.GetComponent<Rigidbody2D>();

        // Use fixed follow distance if set.
        if (followDistance > 0)
        {
            j.autoConfigureDistance = true;
            j.distance = followDistance;
        }

        // Add new joint to the joints list.
        joints.Add(j);

        // Add new collected thing to collection list.
        collected.Add(obj);


    }

    public void RemoveAll()
    {
        // Destroy all joints.
        foreach (var joint in joints)
        {
            Destroy(joint);
        }

        collected.Clear();

    }

    public IEnumerator BreakTrigger()
    {

        GetComponent<CircleCollider2D>().isTrigger = false;
        yield return new WaitForSeconds(2);
        GetComponent<CircleCollider2D>().isTrigger = true;


    }
}
