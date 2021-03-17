using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


namespace Seed
{
    public class Character
    {
        protected int _level = 1;
        protected int _hp = 10;
        protected int _maxhp = 10;
        protected int _attack = 1;
        protected int _defense = 1;
        protected int _skilId1 = 0;
        protected int _skilId2 = 0;
        protected int _skilId3 = 0;
        protected int _skilId4 = 0;
        protected SkillMasterAsset _skillMaster;

        public int CalcAttack(int skill = 0)
        {
            int attackPower = _attack * Random.Range(0, 3);
            if (skill == 1 && _skilId1 != 0)
            {
                var skillMaster = _skillMaster.SkillMasterList.Where(skillMaster => skillMaster.id == _skilId1).FirstOrDefault();
                Debug.Log(skillMaster.SkillName);
                Debug.Log($"before attack:{attackPower}");
                if (skillMaster != null)
                {
                    attackPower += attackPower * skillMaster.ratio / 100;
                }
                Debug.Log($"after attack:{attackPower}");
            }
            if (skill == 2 && _skilId2 != 0)
            {
                attackPower += 2;
            }
            if (skill == 3 && _skilId3 != 0)
            {
                attackPower += 3;
            }if (skill == 4 && _skilId4 != 0)
            {
                attackPower += 4;
            }

            return attackPower;
        }

        public float gethpratio()
        {
            return (float)_hp / (float)_maxhp;
        }

        public void CalcDamage(int damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                
                SceneManager.LoadScene("Result");


            }

            Debug.Log($"{this.GetType().Name}は{damage}のダメージを受けました。残りHPは{_hp}");
        }

        public bool isDead()
        {
            if (_hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Player : Character
    {
        public Player()
        {
            _level = PlayerPrefs.GetInt("LV", 1);
            _attack = PlayerPrefs.GetInt("ATTACK", 1);
            _hp = PlayerPrefs.GetInt("HP", 10);
            _maxhp = PlayerPrefs.GetInt("HP", 10);
            _defense = PlayerPrefs.GetInt("DEFENSE", 1);
            _skilId1 = PlayerPrefs.GetInt("SKILL_ID_1", 0); 
            _skilId2 = PlayerPrefs.GetInt("SKILL_ID_2", 0); 
            _skilId3 = PlayerPrefs.GetInt("SKILL_ID_3", 0); 
            _skilId4 = PlayerPrefs.GetInt("SKILL_ID_4", 0); 

            _skillMaster = Resources.Load("SkillMasterList") as SkillMasterAsset;

            // TODO テスト用
            _skilId1 = 1;
        }
    }

    public class Enemy : Character
    {
        public Enemy(int level)
        {
            _level = level;
            _attack = level * 2;
            _hp = level * 20;
             _maxhp = level * 20;
            _defense = level * 2;
        }
    }
}