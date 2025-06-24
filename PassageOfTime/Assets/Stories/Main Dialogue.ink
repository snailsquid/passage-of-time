-> main_dialogue
VAR stress = 0
VAR favor = 0
VAR cleaning_passed = false
VAR studying_done = false

=== main_dialogue ===
~ temp intro_shown = false
Sister: (...)
Brother: (...)
-> cleaning_check

=== cleaning_check ===
{cleaning_passed:
    ~ favor += 5
    SYSTEM: > Cleaning Passed
    Sister: (Brother seems to be in a good mood—!)
    Sister: (All that cleaning wasn’t for nothing, after all...)

    {not studying_done:
        Sister: (But my assignments...)
        Sister: (No—Brother worked hard for both of us, so he deserves this much...)
        Sister: (Still...)
        Sister: (I just hope... it's worth it in the end.)
    - else:
        Sister: (Besides, I still managed to brush off some of my assignments.)
        Sister: (And what did that all cost?)
        Sister: (My mental health—!)
    }
    -> studying_check
- else:
    ~ stress += 10
    SYSTEM: > Cleaning Failed +5%
    Sister: (Brother's face didn't look good.)
    Sister: (He must not have been able to get a good sleep...)
    Sister: (...Is it because the mess wasn't cleaned up?)
    Sister: (...Brother's not talking.)
    Sister: (...He’s definitely mad...)
    -> studying_check
}

=== studying_check ===
{studying_done:
    Brother: Have you been studying well?
    Sister: (Oh—!)
    *   "I have"
        Sister: Yes, I have.
        Sister: (...)
        Sister: (...Did that come out too stiff?)
        Brother: Hmm...
        ~ favor += 5
        -> post_study_convo
    *   "Of course"
        Sister: Of course, Brother.
        Brother: Is that so?
        Sister: (...)
        Sister: (...Is that so...)
        Sister: (I wonder...)
        Sister: (Does Brother not trust me?)
        ~ favor += 5
        ~ stress += 5
        -> post_study_convo
- else:
    Brother: I trust that you've done your assignments...?
    Sister: (Ah...)
    Sister: (I’m doomed.)
    SYSTEM: >> Studying Not Done +5%
    ~ stress += 5
    Sister: (What should I do—?)
    *   "Tell the truth"
        Sister: ...I haven’t finished them yet.
        Sister: I—I was planning to... It's just...
        Brother: (...)
        Sister: (Oh no...)
        Brother: I see.
        Sister: (Brother looks tired…)
        Sister: (He is disappointed… in me…)
        ~ stress += 5
        Brother: Was there a reason ?
        -> post_study_convo
        *   "Say nothing"
            Sister: (...)
            Brother: (...)
            -> bad_end
        *   "Open up"
            Sister: I was... distracted...
            Sister: With my phone.
            Brother: I see.
            ~ stress += 5
            -> post_study_convo
    *   "Lie about it"
        Sister: Yes... I finished them.
        ~ favor += 5
        Brother: Is that so?
        Sister: Mm-hm. All done.
        Sister: (...)
        Sister: (Then why is your desk empty?)
        ~ stress += 5
        Sister: (--!)
        Brother : Is there anything wrong ?
        Sister: (...Oh.)
        Sister: (...It’s just an imagination...?)
        Sister: No, nothing’s wrong.
        Sister: (Must’ve been my guilty conscience talking...)
        Sister: (Also—it’s not like Brother ever cared to check my room.)
        ~ stress += 5
        Sister: I’m just fine, Brother.
        Brother: (...)
        Brother: Good.
        Sister: (...He believed me?)
        Brother: Then I assume I can look at the finished project.
        Sister: (...Or not.)
        Sister: (Obviously.)
        ~ stress += 5
        Sister: What do I expect ?
        -> post_study_convo
}

=== post_study_convo ===
{cleaning_passed:
    ~ favor += 5
    Sister: (Though… He’s still not talking, after all.)
    Sister: (...)
    Sister: (Well… maybe cleaning is just trivial…?)
    Sister: (It’s nothing… it’s nothing… so I shouldn’t expect anything.)
    
    {not studying_done:
        Sister: (...but—I even sacrificed my assignments for this…)
        Sister: (Well.)
        Sister: (Good riddance.)
        Sister: (Guess all that’s done well—goes to hell~)
        ~ stress += 10
        Brother: Is there… anything wrong?
        *   "Answer"
            Sister: No. Nothing’s wrong.
            Sister: I'm completely fine, Brother.
            Sister: (That didn’t sound bitter, did it...?)
            Sister: (Don’t sound bitter. Don’t sound bitter. Just shut up.)
            ~ stress += 5
            -> reflection
        *   "Don’t answer"
            Sister: (...)
            Brother: (...)
            The clinking of his cutlery fills the silence. The moment passes, maybe forever
            -> skip_end
    - else:
        Sister: (...Well, it might’ve not been spotless...)
        Sister: (But—it’s still been cleaned.)
        Sister: (So… uh…)
        Sister: (...No.)
        Sister: (If it’s not perfect, then it’s not worthy of being commented on, huh.)
        Sister: (But that. Isn’t that quite frustrating...?)
        *   "No"
            Sister: (No… Brother's still eating after all.)
            Sister: (And he hasn't been mad…)
            Sister: (That in itself is already a good thing… right?)
            ~ favor += 5
            -> reflection
        *   "Yes"
            Sister: (Right.)
            Sister: (Then…)
            Sister: (Do I want it to change?)
            Sister: (When I did something, it's not like he ever notices.)
            Sister: (Or if he does... he just didn't comment on it...)
            Sister: (...or maybe...)
            Sister: (Didn't. Even. Care.)
            ~ stress += 5
            -> reflection
    }
- else:
    -> reflection
}

=== reflection ===
{studying_done and cleaning_passed:
    Sister: (But.)
    Sister: (He’s not mad. The room’s clean. My grades are fine.)
    Sister: (I did everything I was supposed to...)
    Sister: (...So why does it still feel like I failed?)
    ~ stress += 5
    *   "Calm down"
        Sister: (...He’s not angry. That’s enough for now.)
        Sister: (...Maybe I’m just tired.)
        A breath. A stilness. Something briefly steadies inside.
        ~ favor += 5
        -> brother_response
    *   "Spiral"
        Sister: (He didn’t say thank you. Or good work. Or even hello.)
        Sister: (...)
        Sister: (Is this all I am to him…?)
        The room feels smaller. Her hands clench against her pants.
        ~ stress += 10
        -> brother_response
- else:
    -> brother_response
}

=== brother_response ===
{favor > 50:
    Brother: You’ve cleaned the shelves well.
    Sister: (...!)
    Brother: I remember leaving dust near the lamp. It’s gone now.
    Sister: You noticed...?
    Brother: Of course.
    The words are quiet, but not unkind
    Sister: (That... was praise, right...?)
    Sister: (Brother praised me...?)
    ~ favor += 5
    ~ stress -= 10
    -> final_choice
- else:
    Brother: ...You’ve been... consistent lately.
    Sister: Huh?
    Brother: I meant to say that earlier.
    Sister: (...What does that mean?)
    Sister: (...Consistent?)
    Sister: (...So I’ve been... average?)
    No praise. No warmth. Just a vague acknowledgment.
    Sister: (Why does it make it worse?)
    ~ stress += 10
    -> final_choice
}

=== final_choice ===
{stress < 50:
    *   "Speak Up"
        Sister: Brother...
        Brother: Yes?
        Sister: Do I ever... make you proud?
        Brother: You think I’m not?
        Sister: I don’t know what you’re thinking most of the time.
        Brother: (...)
        Brother: I don’t say things easily.
        Brother: But I do notice them.
        Brother: And you.
        (His tone isn't warm--but it isn't cold either.)
        Sister: (It's... real.)
        ~ favor += 10
        ~ stress -= 10
        -> the_end
- else:
    *   "Stay Quiet"
        Sister: (...)
        Sister: (It’s pointless.)
        Sister: (If I ask, he’ll just say something vague...)
        Sister: (Or nothing at all.)
        She presses her lips into a line. She swallows her thoughts.
        The moment passes.
        Unspoken.
        ~ stress += 5
        -> bad_end
}

=== bad_end ===
THE END
-> DONE

=== the_end ===
THE END
-> DONE

=== skip_end ===
THE END
-> DONE
