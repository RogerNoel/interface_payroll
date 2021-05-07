Public Class form_payroll

    ' Un Git repository a été créé pour la sauvegarde des fichiers / dossiers
    ' test repo

    '-----------------------------------------------------------------------  A FAIRE ------------------------------------
    ' gérer le cas de lamy

    Const bonus_R_plancher As Double = 1674.49
    Const bonus_R_plafond As Double = 2611.78
    Const bonus_R_indice_employe As Double = 0.2194
    Const bonus_R_maximum_employe As Double = 205.65

    Const bonus_R_indice_ouvrier As Double = 0.237
    Const bonus_R_maximum_ouvrier As Double = 222.1


    Private Sub bt_calculer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_calculer.Click
        calcul_reduc_prp()
        calcul_w()
        ' calcul du brut majoré si ouvrier
        If Me.rad_statut_ouvrier.Checked Then
            Me.lbl_brut_108.Text = calcul108(CDbl(Me.lbl_w.Text))
        Else
            Me.lbl_brut_108.Text = Me.lbl_w.Text
        End If

        ' assignation du montant ONSS dans le label
        Me.lbl_onss.Text = calculONSS(Me.lbl_brut_108.Text)

        ' calcul de S suivant les 3 cas possibles
        If Me.rad_plein.Checked Then
            ' si J = D
            If (Me.lbl_nbre_jours_prestes_et_assimiles_J.Text = Me.lbl_nbr_jrs_prestables_D.Text) Then
                Me.lbl_S.Text = Me.lbl_w.Text
            Else
                Me.lbl_S.Text = calcul_S_tempsPleinIncomplet(Me.lbl_w.Text, Me.lbl_nbre_jours_prestes_et_assimiles_J.Text, Me.lbl_nbr_jrs_prestables_D.Text)
            End If
        ElseIf Me.rad_partiel.Checked Then
            Me.lbl_S.Text = calcul_S_tempsPartiel(Me.lbl_w.Text, Me.lbl_nbr_heures_prestees.Text, Me.lbl_hrs_prestables_U.Text)
        End If

        ' calcul de R du travailleur
        If Me.rad_statut_ouvrier.Checked Then
            Me.lbl_bonusR.Text = calcul_R_ouvrier(Me.lbl_S.Text)
        ElseIf Me.rad_statut_employe.Checked Then
            Me.lbl_bonusR.Text = calcul_R_employe(Me.lbl_S.Text)
        End If

        ' calcul de P
        If Me.rad_plein.Checked And Me.lbl_nbre_jours_prestes_et_assimiles_J.Text = Me.lbl_nbr_jrs_prestables_D.Text Then
            Me.lbl_bonusP.Text = Me.lbl_bonusR.Text
        ElseIf Me.rad_plein.Checked And Me.lbl_nbre_jours_prestes_et_assimiles_J.Text <> Me.lbl_nbr_jrs_prestables_D.Text Then
            Me.lbl_bonusP.Text = calcul_P_temps_plein_incomplet(Me.lbl_nbre_jours_prestes_et_assimiles_J.Text, Me.lbl_nbr_jrs_prestables_D.Text, Me.lbl_bonusR.Text)
        ElseIf Me.rad_partiel.Checked Then
            Me.lbl_bonusP.Text = calcul_P_temps_partiel(Me.lbl_nbr_heures_prestees.Text, Me.lbl_hrs_prestables_U.Text, Me.lbl_bonusR.Text)
        End If

        ' calcul du montant imposable
        Me.lbl_imposable.Text = calcul_imposable(Me.lbl_w.Text, Me.lbl_bonusP.Text, Me.lbl_onss.Text) + Math.Round(Me.lbl_nbr_hrs_M2.Text * Me.txt_remun_ouv.Text * 0.8588, 2, MidpointRounding.AwayFromZero) + Math.Round(Me.lbl_nbr_hrs_M3.Text * Me.txt_remun_ouv.Text * 0.2588, 2, MidpointRounding.AwayFromZero) + Math.Round(Me.lbl_nbr_hrs_AT2.Text * Me.txt_remun_ouv.Text * 0.8588, 2, MidpointRounding.AwayFromZero)


        ' calcul de la tranche de Prp
        Me.lbl_tranche_prp.Text = calcul_tranche_prp(Me.lbl_imposable.Text)

        'détermination du barème PrP
        determination_bareme()

        Me.lbl_prp_base.Text = Me.txt_montant_prp.Text


        Me.lbl_montant_total_frais_depl.Text = calcul_frais_deplacement()

        ' calcul du précompte final
        If CDbl(Me.lbl_total_red_prp.Text) >= CDbl(Me.txt_montant_prp.Text) Then
            Me.lbl_prp_final.Text = 0
        Else
            Me.lbl_prp_final.Text = CDbl(Me.txt_montant_prp.Text) - CDbl(Me.lbl_total_red_prp.Text) + Me.txt_PrP_retenue_supplementaire.Text
        End If

        Me.lbl_brut_108_bis.Text = Me.lbl_brut_108.Text

        ' calcul de la taxe CSSS
        Me.lbl_montant_csss.Text = Math.Round(calcul_CSSS(CDbl(Me.lbl_brut_108.Text)), 2, MidpointRounding.AwayFromZero)

        ' affichage du salaire net
        Me.lbl_salaireNet.Text = CDbl(Me.lbl_imposable.Text) - CDbl(lbl_prp_final.Text) - CDbl(lbl_montant_csss.Text) + Me.lbl_montant_total_frais_depl.Text - Me.txt_montant_retenues_diverses.Text

    End Sub

    ' --------------------------------------------------------------------------------------------------------------------

    ''' <summary>
    ''' Calcule le montant brut selon le statut du travailleur
    ''' </summary>
    ''' <param name="w">représente le brut contrat effectivement presté</param>
    ''' <returns>Renvoie la base brute pour le calcul de l'ONSS</returns>
    ''' <remarks></remarks>
    Function calcul108(ByVal w As Double) As Double
        Dim brut108 As Double
        brut108 = Math.Round(w * 1.08, 2, MidpointRounding.AwayFromZero)
        Return brut108
    End Function

    ''' <summary>
    ''' Calcul de l'ONSS sur base de 13.07%
    ''' </summary>
    ''' <param name="wmaj">Représente le w108</param>
    ''' <returns>Renvoie le montant de l'ONSS</returns>
    ''' <remarks></remarks>
    Function calculONSS(ByVal wmaj As Double) As Double
        Dim onss As Double
        onss = Math.Round(wmaj * 0.1307, 2, MidpointRounding.AwayFromZero)
        Return onss
    End Function

    ''' <summary>
    ''' Calcul de S pour un temps plein qui n'a pas été complètement presté
    ''' </summary>
    ''' <param name="w">représente le w100</param>
    ''' <param name="j">représente le nombre de jours prestés ou assimilés</param>
    ''' <param name="d">représente le nombre de jours ouvrables dans le mois</param>
    ''' <returns>Renvoie un S pour calculer le bonus</returns>
    ''' <remarks>la variable "sas" sert à arrondir w/j à deux décimales</remarks>
    Function calcul_S_tempsPleinIncomplet(ByVal w As Double, ByVal j As Integer, ByVal d As Integer) As Double
        Dim s, sas As Double
        sas = Math.Round(w / j, 2, MidpointRounding.AwayFromZero)
        s = Math.Round(sas * d, 2, MidpointRounding.AwayFromZero)
        Return s
    End Function

    ''' <summary>
    ''' Calcul de S pour un travailleur à temps partiel
    ''' </summary>
    ''' <param name="w">représente le w100</param>
    ''' <param name="h">heures prestées ou assimilées</param>
    ''' <param name="u">jours ouvrables en heures</param>
    ''' <returns>renvoie le salaire de référence S</returns>
    ''' <remarks></remarks>
    Function calcul_S_tempsPartiel(ByVal w As Double, ByVal h As Integer, ByVal u As Integer) As Double
        Dim s, sas As Double
        sas = Math.Round(w / h, 2, MidpointRounding.AwayFromZero)
        s = Math.Round(sas * u, 2, MidpointRounding.AwayFromZero)
        Return s
    End Function

    ''' <summary>
    ''' Calcul le bonus R pour un employé
    ''' </summary>
    ''' <param name="s">salaire de référence S</param>
    ''' <returns>Renvoie le montant du bonus R</returns>
    ''' <remarks>Utilisation de constantes</remarks>
    Function calcul_R_employe(ByVal s As Double) As Double
        If s <= bonus_R_plancher Then
            Return bonus_R_maximum_employe
        ElseIf s > bonus_R_plancher And s <= bonus_R_plafond Then
            Return Math.Round((bonus_R_maximum_employe - (bonus_R_indice_employe * (s - bonus_R_plancher))), 2, MidpointRounding.AwayFromZero)
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Calcule le bonus R pour un ouvrier
    ''' </summary>
    ''' <param name="s">Salaire de référence S</param>
    ''' <returns>Renvoie le montant du bonus R</returns>
    ''' <remarks>Utilisation de constantes</remarks>
    Function calcul_R_ouvrier(ByVal s As Double) As Double
        If s <= bonus_R_plancher Then
            Return bonus_R_maximum_ouvrier
        ElseIf s > bonus_R_plancher And s <= bonus_R_plafond Then
            Return Math.Round((bonus_R_maximum_ouvrier - (bonus_R_indice_ouvrier * (s - bonus_R_plancher))), 2, MidpointRounding.AwayFromZero)
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Calcule P: pro-rata de R selon prestations pour un temps plein
    ''' </summary>
    ''' <param name="j">Nombre de jours prestés et assimilés</param>
    ''' <param name="d">nombre de jours prestables dans le mois</param>
    ''' <param name="r">Bonus R calculé auparavant</param>
    ''' <returns>Le bonus proratisé</returns>
    ''' <remarks></remarks>
    Function calcul_P_temps_plein_incomplet(ByVal j As Integer, ByVal d As Integer, ByVal r As Double) As Double
        Dim sas As Double = Math.Round(j / d, 2, MidpointRounding.AwayFromZero)
        Return Math.Round(sas * r, 2, MidpointRounding.AwayFromZero)
    End Function

    ''' <summary>
    ''' Calcule P: pro-rata de R selon prestations pour un temps partiel
    ''' </summary>
    ''' <param name="h">Nombre d'heures prestées ou assimilées</param>
    ''' <param name="u">Nombre d'heures prestables et assimilées du mois</param>
    ''' <param name="r">Bonus R calculé auparavant</param>
    ''' <returns>Le bonus proratisé</returns>
    ''' <remarks></remarks>
    Function calcul_P_temps_partiel(ByVal h As Integer, ByVal u As Integer, ByVal r As Double) As Double
        Dim sas As Double = Math.Round(h / u, 2, MidpointRounding.AwayFromZero)
        Return Math.Round(sas * r, 2, MidpointRounding.AwayFromZero)
    End Function

    ''' <summary>
    ''' Calcul du montant imposable
    ''' </summary>
    ''' <param name="brut_soumis">Montant brut soumis à l'onss</param>
    ''' <param name="bonus_p">Montant de la réduction d'ONSS</param>
    ''' <param name="montant_onss">Montant ONSS</param>
    ''' <returns>Renvoie le montant imposable</returns>
    ''' <remarks></remarks>
    Function calcul_imposable(ByVal brut_soumis As Double, ByVal bonus_p As Double, ByVal montant_onss As Double) As Double
        If bonus_p > montant_onss Then
            Return brut_soumis
        Else
            Return brut_soumis - montant_onss + bonus_p
        End If
    End Function

    ''' <summary>
    ''' Calcul de la base du PrP selon imposable
    ''' </summary>
    ''' <param name="imposable">Montant de l'imposable</param>
    ''' <returns>Renvoie la tranche de calcul du montant de base du PrP</returns>
    ''' <remarks></remarks>
    Function calcul_tranche_prp(ByVal imposable As Double) As Double
        Return imposable - (imposable Mod 15)
    End Function

    ''' <summary>
    ''' Détermine le barème du PrP selon statut ménage
    ''' </summary>
    ''' <remarks></remarks>
    Sub determination_bareme()
        If Me.rad_men1rev.Checked Then
            Me.lbl_bareme.Text = "Barème 2"
        Else
            Me.lbl_bareme.Text = "Barème 1"
        End If
    End Sub

    ''' <summary>
    ''' Fonction qui calcule le cumul des réductions PrP
    ''' </summary>
    ''' <returns>Renvoie le montant de la réduction</returns>
    ''' <remarks></remarks>
    Function calcul_reduc_prp() As Double
        Dim reduc_prp As Double
        Dim nbr_enfants As Integer
        Dim reduc33 As Double
        ' isolé
        If Me.rad_isole.Checked Then
            Me.lbl_red_prp_isole.Text = 26
            reduc_prp = reduc_prp + 26
        Else
            Me.lbl_red_prp_isole.Text = 0
        End If
        ' enfants à charge
        nbr_enfants = CInt(Me.txt_nbr_enfants.Text) + CInt(Me.txt_nbr_enf_handic.Text)
        Select Case nbr_enfants
            Case 0
                reduc_prp = reduc_prp
                Me.lbl_red_prp_enfants.Text = 0
            Case 1
                reduc_prp = reduc_prp + 37
                Me.lbl_red_prp_enfants.Text = 37
            Case 2
                reduc_prp = reduc_prp + 107
                Me.lbl_red_prp_enfants.Text = 107
            Case 3
                reduc_prp = reduc_prp + 282
                Me.lbl_red_prp_enfants.Text = 282
            Case 4
                reduc_prp = reduc_prp + 494
                Me.lbl_red_prp_enfants.Text = 494
            Case 5
                reduc_prp = reduc_prp + 730
                Me.lbl_red_prp_enfants.Text = 730
            Case 6
                reduc_prp = reduc_prp + 965
                Me.lbl_red_prp_enfants.Text = 965
            Case 7
                reduc_prp = reduc_prp + 1201
                Me.lbl_red_prp_enfants.Text = 1201
            Case 8
                reduc_prp = reduc_prp + 1460
                Me.lbl_red_prp_enfants.Text = 1460
            Case 9 To 99
                reduc_prp = reduc_prp + 1460 + ((nbr_enfants - 8) * 262)
                Me.lbl_red_prp_enfants.Text = 1460 + ((nbr_enfants - 8) * 262)
            Case Else
                MsgBox("Trop d'enfants renseignés")
        End Select
        ' veuf ou parent célibataire
        If Me.chk_veuf.Checked Then
            Me.lbl_veuf.Text = 37
            reduc_prp = reduc_prp + 37
        End If
        ' bénéficiaire handicapé
        If Me.chk_beneficiaire_handic.Checked Then
            Me.lbl_beneficiaire_handicape.Text = 37
            reduc_prp = reduc_prp + 37
        End If
        ' 65+ à charge
        reduc_prp = reduc_prp + CInt(Me.txt_65plus_charge.Text) * 81
        Me.lbl_65plus_charge.Text = CInt(Me.txt_65plus_charge.Text) * 81
        ' 65- charge
        reduc_prp = reduc_prp + CInt(Me.txt_65moins_charge.Text) * 37
        ' conjoint avec revenus < 235
        If Me.chk_conjoint_rev_235moins.Checked Then
            Me.lbl_conjoint_rev_235moins.Text = 117.5
            reduc_prp = reduc_prp + 117.5
        End If
        ' conjoint avec pensions < 469
        If Me.chk_conjoint_pensions_469_mois.Checked Then
            Me.lbl_conjoint_pensions_469_mois.Text = 234.5
            reduc_prp = reduc_prp + 234.5
        End If
        ' calcul de 33.14% de P ou ONSS
        reduc33 = Math.Round(Math.Min(CDbl(Me.lbl_bonusP.Text), CDbl(Me.lbl_onss.Text)) * 0.3314, 2, MidpointRounding.AwayFromZero)
        Me.lbl_reduc_prp_33pc.Text = reduc33
        reduc_prp = reduc_prp + reduc33
        Me.lbl_total_red_prp.Text = reduc_prp
        Return reduc_prp
    End Function

    ''' <summary>
    ''' Calcul du montant de l'impôt de crise suivant brut 108%
    ''' </summary>
    ''' <param name="w108">repésente le brut éventuellement majoré si travailleur ouvrier</param>
    ''' <returns>Renvoie le montant de la taxe CSSS</returns>
    ''' <remarks></remarks>
    Function calcul_CSSS(ByVal w108 As Double) As Double
        If Me.rad_men2rev.Checked Then
            If w108 <= 1095.09 Then
                Return 0
            ElseIf w108 >= 1095.1 And w108 <= 1945.38 Then
                Return 9.3
            ElseIf w108 >= 1945.39 And w108 <= 2190.18 Then
                If (w108 - 1945.38) * 0.076 <= 9.3 Then
                    Return 9.3
                Else
                    Return (w108 - 1945.38) * 0.076
                End If
            ElseIf w108 >= 2190.19 And w108 <= 6038.82 Then
                Return 18.6 + (0.011 * (w108 - 2190.18))
            Else
                Return 51.64
            End If
        Else
            If w108 <= 1095.09 Then
                Return 0
            ElseIf w108 >= 1095.1 And w108 <= 1945.38 Then
                Return 0
            ElseIf w108 >= 1945.39 And w108 <= 2190.18 Then
                Return 0.076 * (w108 - 1945.38)
            ElseIf w108 >= 2190.19 And w108 <= 6038.82 Then
                Return (18.6 + (0.011 * (w108 - 2190.18)))
            Else
                Return 60.94
            End If
        End If
    End Function

    ''' <summary>
    ''' Vérification que toutes les zones de textes sont remplies avec des chiffres ou non vides
    ''' </summary>
    ''' <returns>Retourne un booléen true si tout est bien rempli</returns>
    ''' <remarks></remarks>
    Function verification_non_vide()
        Dim verifOK As Boolean = True

        Return verifOK
    End Function

    ''' <summary>
    ''' Calcule le montant w selon prestations pour remplir lbl_w sur lequel est basé tout le calcul
    ''' </summary>
    Sub calcul_w()
        If Me.rad_statut_employe.Checked = True Then
            If Me.rad_plein.Checked = True Then
                Me.lbl_w.Text = Me.txt_remun_emp.Text
            Else
                ' brut contrat /prestables * prestés
                MsgBox("cas employe temps plein oncomplet ou temps partiel")
            End If
        Else
            If Me.rad_statut_ouvrier.Checked = True Then
                If rad_plein.Checked = True Then
                    Me.lbl_w.Text = Me.txt_remun_ouv.Text * Me.lbl_nbre_heures_prestees_et_assimilees.Text
                Else
                    ' brut contrat * heures prestées
                    Me.lbl_w.Text = txt_remun_ouv.Text * Me.lbl_nbre_heures_prestees_et_assimilees.Text
                End If
            End If
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rad_plein.Checked = True
        Me.rad_isole.Checked = True
        Me.rad_statut_ouvrier.Checked = True
        affichage_remun_txt()
        determination_bareme()
        calcul_w()
    End Sub

    ''' <summary>
    ''' Gestion de l'affichage de l'une ou l'autre boîte texte pour encoder la rémunération du travailleur
    ''' </summary>
    Sub affichage_remun_txt()
        If Me.rad_statut_employe.Checked = True Then
            Me.txt_remun_ouv.Visible = False
            Me.txt_remun_emp.Visible = True
        End If
        If Me.rad_statut_ouvrier.Checked = True Then
            Me.txt_remun_ouv.Visible = True
            Me.txt_remun_emp.Visible = False
        End If
    End Sub

    Private Sub btn_calendrier_afficher_Click(sender As Object, e As EventArgs) Handles btn_calendrier_afficher.Click
        form_Calendrier.Show()
    End Sub

    Private Sub rad_isole_CheckedChanged(sender As Object, e As EventArgs) Handles rad_isole.CheckedChanged
        determination_bareme()
    End Sub

    Private Sub rad_men1rev_CheckedChanged(sender As Object, e As EventArgs) Handles rad_men1rev.CheckedChanged
        determination_bareme()
    End Sub

    Private Sub rad_men2rev_CheckedChanged(sender As Object, e As EventArgs) Handles rad_men2rev.CheckedChanged
        determination_bareme()
    End Sub


    Private Sub rad_statut_ouvrier_CheckedChanged(sender As Object, e As EventArgs) Handles rad_statut_ouvrier.CheckedChanged
        affichage_remun_txt()
    End Sub

    Private Sub rad_statut_employe_CheckedChanged(sender As Object, e As EventArgs) Handles rad_statut_employe.CheckedChanged
        affichage_remun_txt()
    End Sub

    Private Sub Label38_Click(sender As Object, e As EventArgs) Handles Label38.Click

    End Sub

    Private Sub GroupBox11_Enter(sender As Object, e As EventArgs) Handles GroupBox11.Enter

    End Sub
    Function calcul_frais_deplacement()
        Dim montant As Double = 0
        If Me.rad_frais_depl_mensuel.Checked = True Then
            montant = Math.Round(Me.txt_montant_frais_deplacement.Text / Me.lbl_nbr_jrs_prestables_D.Text * Me.lbl_nbr_jours_P.Text, 2, MidpointRounding.AwayFromZero)
        ElseIf Me.rad_frais_depl_hebdo.Checked = True Then
            ' /!\ replacer le "3" par le nombre de jours de travail en semaine suivant régime
            montant = Math.Round(txt_montant_frais_deplacement.Text / 3 * Me.lbl_nbr_jours_P.Text, 2, MidpointRounding.AwayFromZero)
        ElseIf Me.rad_frais_depl_journalier.Checked = True Then
            montant = Math.Round(Me.txt_montant_frais_deplacement.Text * Me.lbl_nbr_jours_P.Text, 2, MidpointRounding.AwayFromZero)
        End If
        Return montant
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        form_codes.Show()
    End Sub

    Private Sub lbl_imposable_Click(sender As Object, e As EventArgs) Handles lbl_imposable.Click

    End Sub

    Private Sub Label46_Click(sender As Object, e As EventArgs) Handles lbl_non_soumis_onss.Click

    End Sub
End Class
