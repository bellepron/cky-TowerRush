using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace cky.Reuseables.Extension
{
    public static class Extensions
    {
        public static Vector3 WorldUnitDirectionX(this Transform actorTr, Vector3 targetPos)
        {
            var direction = targetPos - actorTr.position;
            direction.y = 0.0f;
            direction.z = 0.0f;
            direction.Normalize();

            return direction;
        }
        public static Vector3 LocalUnitDirectionX(this Transform actorTr, Vector3 targetPos)
        {
            var direction = targetPos - actorTr.localPosition;
            direction.y = 0.0f;
            direction.z = 0.0f;
            direction.Normalize();

            return direction;
        }
        public static void TurnToThis(this Transform actorTr, Vector3 targetPos, float rotationSpeed)
        {
            Vector3 direction = targetPos - actorTr.position;
            direction.y = 0;

            float angle = Vector3.Angle(direction, actorTr.forward);
            actorTr.rotation = Quaternion.Slerp(actorTr.rotation,
                                                Quaternion.LookRotation(direction),
                                                Time.deltaTime * rotationSpeed);
        }

        public static void TurnToDirection(this Transform actorTr, Vector3 targetForward, float rotationSpeed)
        {
            //Vector3 direction = targetForward - stateMachineAI.transform.position;
            Vector3 direction = targetForward;
            direction.y = 0;

            float angle = Vector3.Angle(direction, actorTr.forward);
            actorTr.rotation = Quaternion.Slerp(actorTr.rotation,
                                                Quaternion.LookRotation(direction),
                                                Time.deltaTime * rotationSpeed);
        }

        public static void TurnToAngle(this Transform actorTr, Vector3 targetAngle, float rotationSpeed)
        {
            actorTr.rotation = Quaternion.Slerp(actorTr.rotation,
                                                Quaternion.LookRotation(targetAngle),
                                                Time.deltaTime * rotationSpeed);
        }

        public static float Angle(this Transform actorTr, Vector3 targetForward)
        {
            return Vector3.Angle(actorTr.forward, targetForward);
        }

        public static void MoveWithVelocity(this Rigidbody rb, Vector3 targetPos, float moveSpeed, float rotationSpeed)
        {
            var actorTr = rb.transform;

            actorTr.TurnToThis(targetPos, rotationSpeed);

            rb.velocity = actorTr.forward * moveSpeed;
        }

        public static bool CloseToThisXZ(this Transform actorTr, Vector3 targetPos, float targetDistance)
        {
            var actorPos = actorTr.position;
            targetPos.y = actorPos.y;

            var distance = Vector3.Distance(actorPos, (Vector3)targetPos);

            if (distance < targetDistance)
                return true;

            return false;
        }

        public static T RandomFromArray<T>(this IEnumerable<T> array)
        {
            var random = UnityEngine.Random.Range(0, array.Count());
            return array.ElementAt(random);
        }
    }
}