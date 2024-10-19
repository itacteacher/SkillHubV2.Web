function openHardSkillModal() {
    $('#addSkillModal').modal('show');
    $('#addSkillModalLabel').text("Hard Skill creation");
    $('#addSkillModal .modal-body').load('/HardSkills/Create');
}

function openSoftSkillModal() {
    $('#addSkillModal').modal('show');
    $('#addSkillModalLabel').text("Soft Skill creation");
    $('#addSkillModal .modal-body').load('/SoftSkills/Create');
}

document.addEventListener('DOMContentLoaded', function () {
    const hardSkillButton = document.getElementById('openHardSkillModalButton');

    if (hardSkillButton) {
        hardSkillButton.addEventListener('click', openHardSkillModal);
    }
});

document.addEventListener('DOMContentLoaded', function () {
    const softSkillButton = document.getElementById('openSoftSkillModalButton');

    if (softSkillButton) {
        softSkillButton.addEventListener('click', openSoftSkillModal);
    }
});